namespace ModifiedSchemeElGamal.Model.Encryption
{
    /// <summary>
    /// Linear group
    /// </summary>
    public sealed class G
    {
        /// <summary>
        /// Order group
        /// </summary>
        public readonly int N;
        /// <summary>
        /// Modul residue ring
        /// </summary>
        public readonly int P;
        public G(int N, int P) 
        {
            this.N = N;
            this.P = P;
        }
    }
}
