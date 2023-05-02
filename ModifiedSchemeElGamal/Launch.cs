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
        public void TestGenKeys()
        {
            var t = GenerationKeys.GetKeys();
            var gl = t.OpenKey.GL;
            var x = t.OpenKey.X;
            var xa = t.OpenKey.Xa;
            var a = t.SecretKey;
            var p = t.P;
            Console.WriteLine("gl");
            foreach (var g in gl)
            {
                for (var i = 0; i < g.GetLength(0); ++i)
                {
                    for (var j = 0; j < g.GetLength(1); ++j)
                        Console.Write($"{g[i, j]}\t");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine("x");
            for (var i = 0; i < x.GetLength(0); ++i)
            {
                for (var j = 0; j < x.GetLength(1); ++j)
                    Console.Write($"{x[i, j]}\t");
                Console.WriteLine();
            }
            Console.WriteLine("xa");
            for (var i = 0; i < xa.GetLength(0); ++i)
            {
                for (var j = 0; j < xa.GetLength(1); ++j)
                    Console.Write($"{xa[i, j]}\t");
                Console.WriteLine();
            }
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"p = {p}");
            Console.WriteLine($"size = {gl.Count}");
        }
        public void TestModDet(int[,] Matrix,int P)
        {
            var md = MathActions.ModDet(Matrix,P);
            if (MathActions.GCD(md,(double)P) == 1)
            {
                var mdInv = MathActions.MultInv(md,P);
                var t = MathActions.ModMatrixInvCode(Matrix, (int)mdInv, P);
                for (var row = 0; row < t.GetLength(0); ++row)
                {
                    for (var col = 0; col < t.GetLength(1); ++col)
                        Console.Write($"{t[row, col]}\t");
                    Console.WriteLine();
                }
            }
        }
    }
}
