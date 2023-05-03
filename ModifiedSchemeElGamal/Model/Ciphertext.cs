namespace ModifiedSchemeElGamal.Model
{
    public sealed class Ciphertext
    {
        public readonly int[,] Xr;
        public readonly int[,] C;
        public Ciphertext(int[,] Xr, int[,] C)
        {
            this.Xr = Xr;
            this.C = C;
        }
    }
}
