using ModifiedSchemeElGamal;
int[,] c = { { 5, 1, 3 }, { 4, 3, 3 }, { 1, 0, 0 } };
Launch launch = new();
launch.TestModDet(c,7);
//launch.TestGenKeys()
/*using TestLibrary;
int[,] x = { { 4, 9 }, { 136, 135 } };
int[,] m = { { 2, 5 }, { 8, 9 } };
int[,] xa = { { 124, 95 }, { 96, 15 } };

var t = Pow.ModPowMatrix(c,6, 7);
for (var i = 0; i < t.GetLength(0); ++i)
{
    for (var j = 0; j < t.GetLength(1); ++j)
        Console.Write($"{t[i, j]}\t");
    Console.WriteLine();
}
//;*/