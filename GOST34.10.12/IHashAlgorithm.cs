using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOST34_10_12
{
    interface IHashAlgorithm
    {
        public byte[] KeySchedule(byte[] K, int i);
        public byte[] G_n(byte[] N, byte[] h, byte[] m);
        public byte[] AddModulo512(byte[] a, byte[] b);
        public byte[] AddXor512(byte[] a, byte[] b);
        public byte[] S(byte[] state);
        public byte[] P(byte[] state);
        public byte[] L(byte[] state);
        public byte[] E(byte[] K, byte[] m);
    }
}
