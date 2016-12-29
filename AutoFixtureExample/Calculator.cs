using System.Globalization;

namespace AutoFixtureExample
{
    public class Calculator
    {
        public int Value { get; private set; }

        public void Subtract(int number)
        {
            Value -= number;
        }

        public void Add(int number)
        {
            Value += number;
        }
    }
}
