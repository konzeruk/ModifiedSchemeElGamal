using ModifiedSchemeElGamal.Interface;

namespace ModifiedSchemeElGamal.SchemeElGamal
{
    public sealed partial class SEG:ISEG
    {
        /// <summary>
        /// Converts text to line group
        /// </summary>
        /// <param name="Text">Original text</param>
        /// <param name="N">Order line group</param>
        /// <returns>Linear group order N</returns>
        private int[,] TextToGL(string Text, int N)
        {
            var lengthText = Text.Length;
            int numCols;
            if (N == 0 || N > lengthText)
                numCols = 1;
            else
                numCols = (lengthText % N == 0) ? lengthText / N : (lengthText / N) + 1;
            var GL = new int[N, numCols];
            var indT = 0;
            for (var row = 0; row < N; ++row)
                for (var col = 0; col < numCols; ++col)
                    GL[row, col] = (indT < lengthText) ? Text[indT++] : Constants.CompSymbol;
            return GL;
        }
        /// <summary>
        /// Converts linear group to text
        /// </summary>
        /// <param name="M">Linear group</param>
        /// <returns>Original text</returns>
        private string GLToText(int[,] M)
        {
            var Text = string.Empty;
            var numRows = M.GetLength(0);
            var numCols = M.GetLength(1);
            var isCompSymbol = true;
            for (var row = numRows - 1; row >= 0; --row)
                for (var col = numCols - 1; col >= 0; --col)
                {
                    if (M[row, col] != Constants.CompSymbol && isCompSymbol)
                        isCompSymbol = false;
                    if (!isCompSymbol)
                        Text += (char)M[row, col];
                }
            var arrayCharText = Text.ToCharArray();
            Array.Reverse(arrayCharText);
            return new string(arrayCharText);
        }
    }
}
