using System;

namespace FizzBuzzKata
{
    public class FizzBuzzConverter
    {
        public string Convert(int value)
        {
            string result = string.Empty;
            if (value % 3 == 0)
                result = "Fizz";

            if (value % 5 == 0)
                result += "Buzz";

            if (result != string.Empty)
                return result;

            return value.ToString();
        }
    }
}
