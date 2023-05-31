using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace ModifiedSchemeElGamal.HelperClasses
{
    /// <summary>
    /// Cryptographic random number generator
    /// </summary>
    internal static class CRNG
    {
        public static int GenerationInt(int MinValue, int MaxValue) =>
            RandomNumberGenerator.GetInt32(MinValue, MaxValue);
    }
}
