namespace ModifiedSchemeElGamal.HelperClasses
{
    internal sealed class RandomNotRepeat : Random
    {
        private int MinValue,
            MaxValue;
        private Stack<int> List;
        /// <summary>
        /// Initializes a new instance of the System.Random class
        /// </summary>
        /// <param name="MinValue">Included lower limit of returned random number</param>
        /// <param name="MaxValue">The excluded upper limit of the returned random number (maxValue must be greater than or equal to minValue)</param>
        public RandomNotRepeat(int MinValue, int MaxValue)
        {
            this.MaxValue = MaxValue;
            this.MinValue = MinValue;
            GenList();
        }
        /// <summary>
        /// Exception list generation
        /// </summary>
        protected void GenList()
        {
            var temp = new List<int>();
            for (int it = MinValue; it <= MaxValue; ++it)
                temp.Add(it);
            List = new();
            while (temp.Count > 0)
            {
                var addInt = temp[CRNG.GenerationInt(0, temp.Count)];
                List.Push(addInt);
                temp.Remove(addInt);
            }
        }
        /// <summary>
        /// Returns a non-negative random number
        /// </summary>
        /// <returns>Signed integer greater than or equal to minValue and less than maxValue</returns>
        public override int Next()
        {
            if (List.Count > 0)
                return List.Pop();
            else
                GenList();
            return List.Pop();
        }
    }
}
