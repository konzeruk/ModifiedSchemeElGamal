namespace ModifiedSchemeElGamal.Model
{
    internal sealed class Keys
    {
        public readonly OpenKey OpenKey;
        public readonly int SecretKey;
        public readonly int P;
        public Keys(OpenKey OpenKey, int SecretKey, int P)
        {
            this.OpenKey = OpenKey;
            this.SecretKey = SecretKey;
            this.P = P;
        }
    }
}
