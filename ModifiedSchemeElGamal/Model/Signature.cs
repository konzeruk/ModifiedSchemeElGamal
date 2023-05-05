namespace ModifiedSchemeElGamal.Model
{
    public sealed class Signature
    {
        public readonly int[,] Xr;
        public readonly int[,] S;
        public readonly int IndexHashFinction;
        public Signature(int[,] Xr, double[,] S, int IndexHashFinction)
        {
            this.Xr = Xr;
            this.S = S;
            this.IndexHashFinction = IndexHashFinction;
        }
    }
}
