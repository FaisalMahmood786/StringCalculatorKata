using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("");
           Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_SingleNumber_ReturnsNumber()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1,2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_UnknownNumberOfNumbers_ReturnsSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1,2,3,4,5");
            Assert.AreEqual(15, result);
        }

        [Test]
        public void Add_NewlineDelimiter_ReturnsSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }
        [Test]
        public void Add_NumbersWithCustomDelimiter_ReturnsTheirSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//;\n1;2");
            Assert.AreEqual(3, result);
        }
        [Test]
        public void Add_NegativeNumber_ThrowsException()
        {
            var calculator = new StringCalculator();
            var ex = Assert.Throws<ArgumentException>(() => calculator.Add("1, -2"));
            Assert.AreEqual("Negatives not allowed: -2", ex.Message);
        }
        [Test]
        public void Add_NumbersGreaterThan1000_IgnoredInSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("2,1001");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Add_CustomDelimiterOfAnyLength_ReturnsTheirSum()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//[***]\n1***2***3");
            Assert.AreEqual(6, result);
        }

    }
}

