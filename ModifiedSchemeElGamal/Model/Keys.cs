namespace ModifiedSchemeElGamal.Model
{
    internal sealed class Keys
    {
        public readonly OpenKey OpenKey;
        public readonly int SecretKey;
        public Keys(OpenKey OpenKey, int SecretKey)
        {
            this.OpenKey = OpenKey;
            this.SecretKey = SecretKey;
        }
    }
}
