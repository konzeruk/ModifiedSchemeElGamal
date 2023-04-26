namespace ModifiedSchemeElGamal.HelperClasses
{
    internal class RandomNotRepeat : Random
    {
        private int MinValue,
            MaxValue;
        private Stack<int> List;
        /// <summary>
        /// Инициализирует новый экземпляр класса System.Random с помощью зависимого
        //  от времени начального значения по умолчанию.
        /// </summary>
        /// <param name="min">Включенной нижний предел возвращаемого случайного числа.</param>
        /// <param name="max">Исключенный верхний предел возвращаемого случайного числа. Значение maxValue должно быть больше или равно значению minValue.</param>
        public RandomNotRepeat(int MinValue, int MaxValue)
        {
            this.MaxValue = MaxValue;
            this.MinValue = MinValue;
            GenList();
        }
        /// <summary>
        /// Генерация списка исключений
        /// </summary>
        protected void GenList()
        {
            List<int> temp = new List<int>();
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
        /// Возвращает неотрицательное случайное число.
        /// </summary>
        /// <returns>32-разрядное целое число со знаком большее или равное minValue и меньше, чем maxValue; то есть, диапазон возвращаемого значения включает minValue, не включает maxValue. Если значение параметра minValue равно значению параметра maxValue, то возвращается значение minValue.</returns>
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
