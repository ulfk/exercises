

namespace PrimzahlLib
{
    public class Primzahl
    {
        // Online-Test fuer auf Primzahl: https://www.matheretter.de/rechner/primzahltest

        public static bool IsPrimzahl(int value)
        {
            var isPrime = true;
            var maxVal = value / 2;
            for (int i = 2; i <= maxVal && isPrime; i += i > 2 ? 2 : 1)
            {
                isPrime = value % i != 0;
            }

            return isPrime;
        }
    }
}
