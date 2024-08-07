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
    }
}

