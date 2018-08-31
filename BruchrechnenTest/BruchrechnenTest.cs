using System;
using Bruchrechnen;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BruchrechnenTest
{
    [TestClass]
    public class BruchrechnenTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var bruch = new Bruch(2, 3);
            bruch.Zaehler.Should().Be(2);
            bruch.Nenner.Should().Be(3);
        }

        [TestMethod]
        public void TestNennerNull()
        {
            Action comparison = () =>
            {
                var bruch = new Bruch(2,  0);
            };
            comparison.Should().Throw<ArgumentException>();

        }

        [TestMethod]
        public void TestAddition()
        {
            var bruchLinks = new Bruch(2, 3);
            var bruchRechts = new Bruch(1, 4);

            var bruch = bruchLinks + bruchRechts;
            bruch.Zaehler.Should().Be(11);
            bruch.Nenner.Should().Be(12);
        }

        [TestMethod]
        public void TestAdditionMitKuerzen()
        {
            var bruchLinks = new Bruch(2, 8);
            var bruchRechts = new Bruch(1, 4);

            var bruch = bruchLinks + bruchRechts;
            bruch.Zaehler.Should().Be(1);
            bruch.Nenner.Should().Be(2);
        }

        [TestMethod]
        public void TestAdditionMitKuerzen2()
        {
            var bruchLinks = new Bruch(37, 8);
            var bruchRechts = new Bruch(32, 60);

            var bruch = bruchLinks + bruchRechts;
            bruch.Zaehler.Should().Be(619);
            bruch.Nenner.Should().Be(120);
        }

        [TestMethod]
        public void TestAdditionMitKuerzen3()
        {
            var bruchLinks = new Bruch(2, 2);
            var bruchRechts = new Bruch(4, 4);

            var bruch = bruchLinks + bruchRechts;
            bruch.Zaehler.Should().Be(2);
            bruch.Nenner.Should().Be(1);
        }

        [TestMethod]
        public void TestSubtraktionMitKuerzen()
        {
            var bruchLinks = new Bruch(4, 8);
            var bruchRechts = new Bruch(4, 16);

            var bruch = bruchLinks - bruchRechts;
            bruch.Zaehler.Should().Be(1);
            bruch.Nenner.Should().Be(4);
        }

        [TestMethod]
        public void TestSubtraktionMitKuerzen2()
        {
            var bruchLinks = new Bruch(12, 8);
            var bruchRechts = new Bruch(28, 16);

            var bruch = bruchLinks - bruchRechts;
            bruch.Zaehler.Should().Be(-1);
            bruch.Nenner.Should().Be(4);
        }

        [TestMethod]
        public void TestMultiplikation()
        {
            var bruchLinks = new Bruch(2, 4);
            var bruchRechts = new Bruch(1, 3);

            var bruch = bruchLinks * bruchRechts;
            bruch.Zaehler.Should().Be(1);
            bruch.Nenner.Should().Be(6);
        }

        [TestMethod]
        public void TestMultiplikation2()
        {
            var bruchLinks = new Bruch(2, 4);
            var bruchRechts = new Bruch(1, 4);

            var bruch = bruchLinks * bruchRechts;
            bruch.Zaehler.Should().Be(1);
            bruch.Nenner.Should().Be(8);
        }

        [TestMethod]
        public void TestDivision()
        {
            var bruchLinks = new Bruch(2, 4);
            var bruchRechts = new Bruch(1, 4);

            var bruch = bruchLinks / bruchRechts;
            bruch.Zaehler.Should().Be(2);
            bruch.Nenner.Should().Be(1);
        }

        [TestMethod]
        public void TestDivision2()
        {
            var bruchLinks = new Bruch(-2, 4);
            var bruchRechts = new Bruch(1, 4);

            var bruch = bruchLinks / bruchRechts;
            bruch.Zaehler.Should().Be(-2);
            bruch.Nenner.Should().Be(1);
        }

        [TestMethod]
        public void TestDivision3()
        {
            var bruchLinks = new Bruch(2, 4);
            var bruchRechts = new Bruch(-1, 4);

            var bruch = bruchLinks / bruchRechts;
            bruch.Zaehler.Should().Be(-2);
            bruch.Nenner.Should().Be(1);
        }

        [TestMethod]
        public void TestDivision4()
        {
            var bruchLinks = new Bruch(-2, 4);
            var bruchRechts = new Bruch(-1, 4);

            var bruch = bruchLinks / bruchRechts;
            bruch.Zaehler.Should().Be(2);
            bruch.Nenner.Should().Be(1);
        }
    }
}
