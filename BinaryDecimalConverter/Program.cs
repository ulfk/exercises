/*
 * Lösung zu dieser Aufgabenstellung:
 * https://trainyourprogrammer.de/csharp-189-zahlen-umwandeln-binaer-zu-dezimal.html
 * 
 * Schreibe eine Funktion, die Zahlen aus dem Dualsystem in Zahlen des Dezimalsystems umwandelt.
 *
 * Beispiel:
 * Binär: 11010
 * Dezimal: 26 
 * 
 */
namespace Csharp_189_BinaryDecimalConverter
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            // loop to enter and check several numbers in a row
            do
            {
                Console.Write("Enter binary number or 'Q' to quit: ");
                inputString = Console.ReadLine();
                if (IsValidBinaryNumber(inputString))
                {
                    var resultInteger = ConvertBinaryToDecimal(inputString);
                    Console.WriteLine($"Binary={inputString}  -->  Decimal={resultInteger}\n");
                }
                else
                {
                    Console.WriteLine("ERROR: Invalid input! \n" +
                                      "   Allowed characters: '0' and '1'\n" +
                                      "   Minimum length: 1 character\n" +  
                                      "   Maximum length: 31 characters\n" + 
                                      "   Example input:  100110\n");
                }
            } while (inputString.ToLower() != "q");
        }

        static int ConvertBinaryToDecimal(string binaryString)
        {
            var result = 0;
            var length = binaryString.Length;
            for(var idx = 0; idx < length; idx++)
            {
                // get digits from right to left and convert them to decimal
                var value = binaryString[length - (idx + 1)] == '1' ? 1 : 0;
                result += value * (1 << idx);
            }

            return result;
        }

        static bool IsValidBinaryNumber(string binaryString)
        {
            return binaryString.Length < 32
                && Regex.IsMatch(binaryString, @"^([01]+)$");
        }
    }
}
