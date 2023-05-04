using System.Numerics;
using System.Security.Cryptography;
using GOST34_10_12;

namespace ModifiedSchemeElGamal.HelperClasses
{
    internal static class HashFunctions
    {
        public static BigInteger GetHashSHA256(string Text)
        {
            using (SHA256 SHA256 = SHA256.Create())
                return new BigInteger(SHA256.ComputeHash(System.Text.Encoding.ASCII.GetBytes(Text)));
        }
        public static BigInteger GetHashMD5(string Text)
        {
            using (MD5 MD5 = MD5.Create())
                return new BigInteger(MD5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(Text)));
        }
        public static BigInteger GetHashGOST(string Text)
        {
            using (GOST GOST = GOST.Create())
                return new BigInteger(GOST.ComputeHash(System.Text.Encoding.ASCII.GetBytes(Text)));
        }
    }
}
