using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimzahlLib;

namespace PrimzahlTest
{
    [TestClass]
    public class PrimzahlTest
    {
        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, true)]
        [DataRow(3, true)]
        [DataRow(4, false)]
        [DataRow(5, true)]
        [DataRow(6, false)]
        [DataRow(7, true)]
        [DataRow(8, false)]
        [DataRow(9, false)]
        [DataRow(10, false)]
        [DataRow(11, true)]
        [DataRow(12, false)]
        [DataRow(13, true)]
        [DataRow(14, false)]
        [DataRow(15, false)]
        [DataRow(16, false)]
        [DataRow(17, true)]
        [DataRow(20, false)]
        [DataRow(21, false)]
        [DataRow(22, false)]
        [DataRow(42, false)]
        [DataRow(61, true)]
        [DataRow(97, true)]
        [DataRow(123, false)]
        [DataRow(127, true)]
        [DataRow(901, false)]
        [DataRow(907, true)]
        [DataRow(1931, true)]
        [DataRow(19319, true)]
        [DataRow(193201, true)]
        [DataRow(1932011, true)]
        [DataRow(19320156, false)]
        [DataRow(19320157, true)]
        public void TestIsPrimzahl(int value, bool isPrime)
        {
            Primzahl.IsPrimzahl(value).Should().Be(isPrime);
        }
    }
}
