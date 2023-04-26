namespace ModifiedSchemeElGamal.Model
{
    internal sealed class OpenKey
    {
        public readonly List<int[,]> GL;
        public readonly int[,] X;
        public readonly int[,] Xa;
        public OpenKey(List<int[,]> GL, int[,] X, int[,] Xa)
        {
            this.GL = GL;
            this.X = X;
            this.Xa = Xa;
        }
    }
}
