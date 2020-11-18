using NUnit.Framework;
using FizzBuzzKata;

namespace FizzBuzzKata.Tests
{
    /*
     * 1 -> 1
     * 2 -> 2
     * 3 -> Fizz
     * 4 -> 4
     * 5 -> Buzz
     * 6 -> Fizz
     * 10 -> Buzz
     * 15 -> FizzBuzz */
    public class FizzBuzzConverterTests
    {
        [Test]
        public void Init()
        {
            new FizzBuzzConverter();
        }

        [Test]
        public void Given_1_than_1_is_returned()
        {
            var sut = new FizzBuzzConverter();

            var result = sut.Convert(1);

            Assert.AreEqual(1, result);
        }
    }
}