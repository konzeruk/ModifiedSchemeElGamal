namespace GOST34_10_12
{
    public class GOST : HashAlgorithm
    {
        public static GOST Create(int HashSizeInBits = 256) =>
            new GOST(HashSizeInBits);
        private GOST(int HashSizeInBits):
            base(HashSizeInBits)
        { }
        public override byte[] ComputeHash(byte[] Message) => 
            GetHash(Message);
    }
}