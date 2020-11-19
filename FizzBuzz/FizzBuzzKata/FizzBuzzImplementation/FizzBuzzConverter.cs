using System;

namespace FizzBuzzKata
{
    public class FizzBuzzConverter
    {
        public string Convert(int value)
        {
            if (value == 3)
                return "Fizz";

            return value.ToString();
        }
    }
}
