using ModifiedSchemeElGamal.HelperClasses;
using ModifiedSchemeElGamal.LinearAlgebra;

namespace ModifiedSchemeElGamal
{
    public class Launch
    {
        public List<int[,]>? Start(int N, int P)
        {
            var GL = GroupLinear.Instance;
            return GL.GenerationGL(N, P);
        }
    }
}
