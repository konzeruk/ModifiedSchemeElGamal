namespace ModifiedSchemeElGamal.Model
{
    public sealed class Keys
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
