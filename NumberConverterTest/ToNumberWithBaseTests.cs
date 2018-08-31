using System;
using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberConverterLib;

namespace NumberConverterTest
{
    [TestClass]
    public class ToNumberWithBaseTests
    {
        [TestMethod]
        public void TestBaseNegative()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.ToNumberWithBase(123L, -10);

            };
            comparison.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestBaseTooBig()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.ToNumberWithBase(123L, 63);

            };
            comparison.Should().Throw<ArgumentException>();
        }

        //[TestMethod]
        // Der hier getestete Fehlerfall kann nur auftreten, wenn die zulaessige max. Basis erhöht aber 
        // keine weiteren gültigen Zeichen definiert werden.
        public void TestInvalidValue()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.ToNumberWithBase(62L, 63);

            };
            comparison.Should().Throw<InvalidDataException>();
        }

        [TestMethod]
        public void TestValueNegative()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.ToNumberWithBase(-2L, 10);

            };
            comparison.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestBase10()
        {
            var numConv = new NumberConverter();
            var result = numConv.ToNumberWithBase(12345L, 10);
            result.Should().Be("12345");
        }

        [TestMethod]
        public void TestBase2()
        {
            var numConv = new NumberConverter();
            var result = numConv.ToNumberWithBase(748L, 2);
            result.Should().Be("1011101100");
        }

        [TestMethod]
        public void TestBase60_ProximitY()
        {
            var numConv = new NumberConverter();
            var result = numConv.ToNumberWithBase(4349785339169734L, 60);
            result.Should().Be("ProximitY");
        }

        [TestMethod]
        public void TestBase60_Proximity()
        {
            var numConv = new NumberConverter();
            var result = numConv.ToNumberWithBase(4961874665420178L, 61);
            result.Should().Be("Proximity");
        }

        [TestMethod]
        public void TestBase62()
        {
            var numConv = new NumberConverter();
            var result = numConv.ToNumberWithBase(71623871263817236L, 62);
            result.Should().Be("5I2MPyWCeK");
        }

        [TestMethod]
        public void TestBase60()
        {
            var numConv = new NumberConverter();
            var result = numConv.ToNumberWithBase(0L, 60);
            result.Should().Be("0");
        }

        [TestMethod]
        public void TestBase37()
        {
            var numConv = new NumberConverter();
            var result = numConv.ToNumberWithBase(0L, 37);
            result.Should().Be("0");
            result = numConv.ToNumberWithBase(47110815L, 37);
            result.Should().Be("P52LA");
        }
    }
}
