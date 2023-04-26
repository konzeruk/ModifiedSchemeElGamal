// See https://aka.ms/new-console-template for more information
using ModifiedSchemeElGamal;
Launch launch = new();
var N = 5;
var P = 137;
var GL = launch.Start(N, P);
if (GL != null)
{
    foreach (var g in GL)
    {
        for (var i = 0; i < N; ++i)
        {
            for (var j = 0; j < N; ++j)
            {
                Console.Write($"{g[i, j]}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
