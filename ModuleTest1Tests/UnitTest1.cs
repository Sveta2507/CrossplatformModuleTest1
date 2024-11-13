using System;
using Xunit;
using Module;

namespace ModuleTest1Tests
{
    public class PrimeDivisorsTests
    {
        [Fact]
        public void TestDivisors_1()
        {
            long input = 1;
            string output = "1";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }

        [Fact]
        public void TestDivisors_2()
        {
            long input = 1019;
            string output = "2";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }

        [Fact]
        public void TestDivisors_12()
        {
            long input = 12;
            string output = "6";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }

        [Fact]
        public void TestDivisors_239()
        {
            long input = 239;
            string output = "2";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }

        [Fact]
        public void TestDivisors_1019()
        {
            long input = 1000000000000000001;
            string output = "число некоректне";

            string result = Program.GetDivisorsCount(input);

            Assert.Equal(output, result);
        }
    }
}