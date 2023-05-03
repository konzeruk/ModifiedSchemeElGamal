using ModifiedSchemeElGamal.HelperClasses;
using ModifiedSchemeElGamal.LinearAlgebra;
using ModifiedSchemeElGamal.MathematicalOperators;
using ModifiedSchemeElGamal.Model;
using ModifiedSchemeElGamal.SchemeElGamal;

namespace ModifiedSchemeElGamal
{
    public class Launch
    {
        public void TestEncr()
        {
            int[,] x = { { 2, 4, 6 }, { 5, 5, 2 }, { 1, 1, 0 } };
            int[,] xa = { { 0, 0, 1 }, { 3, 4, 4 }, { 4, 1, 4 } };
            var ok = new OpenKey(new G(3, 7), x, xa);
            var seg = new SEG();
            var t = seg.Encryption("", ok);
            for (var i = 0; i < t.Xr.GetLength(0); ++i)
            {
                for (var j = 0; j < t.Xr.GetLength(1); ++j)
                    Console.Write($"{t.Xr[i, j]}\t");
                Console.WriteLine();
            }
            Console.WriteLine();
            for (var i = 0; i < t.C.GetLength(0); ++i)
            {
                for (var j = 0; j < t.C.GetLength(1); ++j)
                    Console.Write($"{t.C[i, j]}\t");
                Console.WriteLine();
            }
        }
        public void TestGenKeys()
        {
            var t = GenerationKeys.GetKeys();
            var n = t.OpenKey.GL.N;
            var x = t.OpenKey.X;
            var xa = t.OpenKey.Xa;
            var a = t.SecretKey;
            var p = t.OpenKey.GL.P;
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
            Console.WriteLine($"n = {n}");
        }
        public void TestModDet(int[,] Matrix,int P)
        {
           var t = MathActions.ModMatrixInv(Matrix, P);
            for(var i =0;i<t.GetLength(0);++i)
            {
                for (var j = 0; j < t.GetLength(1); ++j)
                    Console.Write($"{t[i, j]}\t");
                Console.WriteLine();
            }
        }
    }
}
