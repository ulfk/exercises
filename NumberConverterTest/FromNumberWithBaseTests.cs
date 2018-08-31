using System;
using System.IO;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberConverterLib;

namespace NumberConverterTest
{
    [TestClass]
    public class FromNumberWithBaseTests
    {
        [TestMethod]
        public void TestNullValue()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.FromNumberWithBase(null, 10);

            };
            comparison.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void TestEmptyValue()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.FromNumberWithBase(string.Empty, 10);

            };
            comparison.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void TestBaseZero()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.FromNumberWithBase("1", 0);

            };
            comparison.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestBaseNegative()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.FromNumberWithBase("1", -1);

            };
            comparison.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestBase10ValidValues()
        {
            var numConv = new NumberConverter();
            var result = numConv.FromNumberWithBase("1234", 10);
            result.Should().Be(1234);
            result = numConv.FromNumberWithBase("34178", 10);
            result.Should().Be(34178);
            result = numConv.FromNumberWithBase("4", 10);
            result.Should().Be(4);
        }

        [TestMethod]
        public void TestBase62InvalidCharacters()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.FromNumberWithBase("(/&123AB+#", 62);

            };
            comparison.Should().Throw<InvalidDataException>();
        }

        [TestMethod]
        public void TestBase10InvalidValue()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.FromNumberWithBase("123AB", 10);

            };
            comparison.Should().Throw<InvalidDataException>();
        }

        [TestMethod]
        public void TestBase36InvalidValue()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.FromNumberWithBase("123ABa", 36);

            };
            comparison.Should().Throw<InvalidDataException>();
        }

        [TestMethod]
        public void TestBase7InvalidValue()
        {
            var numConv = new NumberConverter();
            Action comparison = () =>
            {
                var result = numConv.FromNumberWithBase("128", 7);

            };
            comparison.Should().Throw<InvalidDataException>();
        }

        [TestMethod]
        public void TestBase2()
        {
            var numConv = new NumberConverter();
            var result = numConv.FromNumberWithBase("101", 2);
            result.Should().Be(5);
            result = numConv.FromNumberWithBase("1011101100", 2);
            result.Should().Be(748);
        }

        [TestMethod]
        public void TestBase8()
        {
            var numConv = new NumberConverter();
            var result = numConv.FromNumberWithBase("1354", 8);
            result.Should().Be(748);
        }

        [TestMethod]
        public void TestBase16()
        {
            var numConv = new NumberConverter();
            var result = numConv.FromNumberWithBase("2EC", 16);
            result.Should().Be(748);
        }

        [TestMethod]
        public void TestProximity()
        {
            var numConv = new NumberConverter();
            var result = numConv.FromNumberWithBase("Proximity", 61);
            result.Should().Be(4961874665420178L);
            // 4.961.874.665.420.178
        }

        [TestMethod]
        public void TestProximitY()
        {
            var numConv = new NumberConverter();
            var result = numConv.FromNumberWithBase("ProximitY", 60);
            result.Should().Be(4349785339169734L);
            // 4.349.785.339.169.734
        }

        [TestMethod]
        public void TestBase37()
        {
            var numConv = new NumberConverter();
            var result = numConv.FromNumberWithBase("P52LA", 37);
            result.Should().Be(47110815L);
        }
    }
}
