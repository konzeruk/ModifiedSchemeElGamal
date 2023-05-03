namespace ModifiedSchemeElGamal.Model
{
    public sealed class OpenKey
    {
        public readonly G GL;
        public readonly int[,] X;
        public readonly int[,] Xa;
        public OpenKey(G GL, int[,] X, int[,] Xa)
        {
            this.GL = GL;
            this.X = X;
            this.Xa = Xa;
        }
    }
}
