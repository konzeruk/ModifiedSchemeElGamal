using System.Numerics;
using System.Security.Cryptography;
using GOST34_10_12;

namespace ModifiedSchemeElGamal.HelperClasses
{
    internal static sealed class HashFunctions
    {
        /// <summary>
        /// Get hash value appropriate IndexHashFunctions
        /// </summary>
        /// <param name="IndexHashFunctions"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static BigInteger GetHash(int IndexHashFunctions, byte[] Message) => IndexHashFunctions switch
        {
            0 => GetHashSHA256(Message),
            1 => GetHashMD5(Message),
            2 => GetHashGOST(Message)
        };
        /// <summary>
        /// Hash function SHA256
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>Digest message</returns>
        public static BigInteger GetHashSHA256(byte[] Message)
        {
            using (SHA256 SHA256 = SHA256.Create())
                return new BigInteger(SHA256.ComputeHash(Message));
        }
        /// <summary>
        /// Hash function MD5
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>Digest message</returns>
        public static BigInteger GetHashMD5(byte[] Message)
        {
            using (MD5 MD5 = MD5.Create())
                return new BigInteger(MD5.ComputeHash(Message));
        }
        /// <summary>
        /// Hash function GOST84.10
        /// </summary>
        /// <param name="Message"></param>
        /// <returns>Digest message</returns>
        public static BigInteger GetHashGOST(byte[] Message)
        {
            using (GOST GOST = GOST.Create())
                return new BigInteger(GOST.ComputeHash(Message));
        }
    }
}
