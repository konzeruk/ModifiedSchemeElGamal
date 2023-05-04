using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOST34_10_12
{
    public abstract class HashAlgorithm : IDisposable, IHashAlgorithm
    {
        private int HashSizeInBits;
        private byte[] iv = new byte[64],
            N = new byte[64],
            Sigma = new byte[64];
        public abstract byte[] ComputeHash(byte[] Message);
        protected HashAlgorithm(int HashSizeInBits)
        {
            try
            {
                if (HashSizeInBits == 512 || HashSizeInBits == 256)
                {
                    for (var it = 0; it < 64; ++it)
                    {
                        N[it] = Sigma[it] = 0x00;
                        iv[it] = (byte)((HashSizeInBits == 256) ? 0x01 : 0x00);
                    }
                    this.HashSizeInBits = HashSizeInBits;
                }
                else
                    new Exception("Incorrectly specified HashSizeInBits");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected byte[] GetHash(byte[] message)
        {
            byte[] paddedMes = new byte[64];
            int len = message.Length * 8;
            byte[] h = new byte[64];
            Array.Copy(iv, h, 64);
            byte[] N_0 ={
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
            };
            if (HashSizeInBits == 512)
            {
                for (int i = 0; i < 64; i++)
                {
                    N[i] = 0x00;
                    Sigma[i] = 0x00;
                    iv[i] = 0x00;
                }
            }
            else if (HashSizeInBits == 256)
            {
                for (int i = 0; i < 64; i++)
                {
                    N[i] = 0x00;
                    Sigma[i] = 0x00;
                    iv[i] = 0x01;
                }
            }
            byte[] N_512 = BitConverter.GetBytes(512);
            int inc = 0;
            while (len >= 512)
            {
                inc++;
                byte[] tempMes = new byte[64];
                Array.Copy(message, message.Length - inc * 64, tempMes, 0, 64);
                h = G_n(N, h, tempMes);
                N = AddModulo512(N, N_512.Reverse().ToArray());
                Sigma = AddModulo512(Sigma, tempMes);
                len -= 512;
            }
            byte[] message1 = new byte[message.Length - inc * 64];
            Array.Copy(message, 0, message1, 0, message.Length - inc * 64);
            if (message1.Length < 64)
            {
                for (int i = 0; i < (64 - message1.Length - 1); i++)
                {
                    paddedMes[i] = 0;
                }
                paddedMes[64 - message1.Length - 1] = 0x01;
                Array.Copy(message1, 0, paddedMes, 64 - message1.Length, message1.Length);
            }
            h = G_n(N, h, paddedMes);
            byte[] MesLen = BitConverter.GetBytes(message1.Length * 8);
            N = AddModulo512(N, MesLen.Reverse().ToArray());
            Sigma = AddModulo512(Sigma, paddedMes);
            h = G_n(N_0, h, N);
            h = G_n(N_0, h, Sigma);
            if (HashSizeInBits == 512)
                return h;
            else
            {
                byte[] h256 = new byte[32];
                Array.Copy(h, 0, h256, 0, 32);
                return h256;
            }
        }
        public byte[] S(byte[] state)
        {
            byte[] result = new byte[64];
            for (int i = 0; i < 64; i++)
                result[i] = Сonstants.Sbox[state[i]];
            return result;
        }

        public byte[] P(byte[] state)
        {
            byte[] result = new byte[64];
            for (int i = 0; i < 64; i++)
                result[i] = state[Сonstants.Tau[i]];
            return result;
        }

        public byte[] L(byte[] state)
        {
            byte[] result = new byte[64];
            for (int i = 0; i < 8; i++)
            {
                ulong t = 0;
                byte[] tempArray = new byte[8];
                Array.Copy(state, i * 8, tempArray, 0, 8);
                tempArray = tempArray.Reverse().ToArray();
                BitArray tempBits1 = new BitArray(tempArray);
                bool[] tempBits = new bool[64];
                tempBits1.CopyTo(tempBits, 0);
                tempBits = tempBits.Reverse().ToArray();
                for (int j = 0; j < 64; j++)
                    if (tempBits[j] != false)
                        t = t ^ Сonstants.A[j];
                byte[] ResPart = BitConverter.GetBytes(t).Reverse().ToArray();
                Array.Copy(ResPart, 0, result, i * 8, 8);
            }
            return result;
        }
        public byte[] E(byte[] K, byte[] m)
        {
            byte[] state = AddXor512(K, m);
            for (int i = 0; i < 12; i++)
            {
                state = S(state);
                state = P(state);
                state = L(state);
                K = KeySchedule(K, i);
                state = AddXor512(state, K);
            }
            return state;
        }
        public byte[] KeySchedule(byte[] K, int i)
        {
            K = AddXor512(K, Сonstants.C[i]);
            K = S(K);
            K = P(K);
            K = L(K);
            return K;
        }
        public byte[] G_n(byte[] N, byte[] h, byte[] m)
        {
            byte[] K = AddXor512(h, N);
            K = S(K);
            K = P(K);
            K = L(K);
            byte[] t = E(K, m);
            t = AddXor512(t, h);
            byte[] newh = AddXor512(t, m);
            return newh;
        }
        public byte[] AddModulo512(byte[] a, byte[] b)
        {
            byte[] temp = new byte[64];
            int i = 0, t = 0;
            byte[] tempA = new byte[64];
            byte[] tempB = new byte[64];
            Array.Copy(a, 0, tempA, 64 - a.Length, a.Length);
            Array.Copy(b, 0, tempB, 64 - b.Length, b.Length);
            for (i = 63; i >= 0; i--)
            {
                t = tempA[i] + tempB[i] + (t >> 8);
                temp[i] = (byte)(t & 0xFF);
            }
            return temp;
        }
        public byte[] AddXor512(byte[] a, byte[] b)
        {
            byte[] c = new byte[64];
            for (int i = 0; i < 64; i++)
                c[i] = (byte)(a[i] ^ b[i]);
            return c;
        }
        public void Dispose()
        { }
    }
}
