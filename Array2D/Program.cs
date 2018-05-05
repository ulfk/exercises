/*
 * Lösung zu dieser Aufgabenstellung:
 * https://trainyourprogrammer.de/csharp-199-ermittlung-von-zeilen--und-spaltennummer-eines-2d-array-feldes.html
 * 
 * Die Felder eines "unendlich" großen 2D-Arrays seien nach folgendem "Diagonal-Schema" nummeriert:
 *
 * 1 2 4 7 . . .
 * 3 5 8 . . . .
 * 6 9 . . . . .
 * 10 . . . . . .
 * . . . . . . usw.
 * 
 * Man schreibe ein Programm, das für eine gegebene Feldnummer N die Zeilen- (ZN) und die Spaltennummer (SN) zurückgibt.
 * Zeilen- und Spaltennummerierungen beginnen wie üblich mit 0.
 * 
 * Beispiele:
 * N = 8 -> ZN = 1, SN = 2
 * N = 31 -> ZN = 2, SN = 5 
 * 
 */

namespace Csharp_199_2DArray
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            // loop to enter and check several numbers in a row
            do
            {
                Console.Write("Enter integer number or 'Q' to quit: ");
                inputString = Console.ReadLine();
                if(int.TryParse(inputString,out int inputNumber))
                {
                    CalculateArrayIndexes(inputNumber, out int resultColumn, out int resultRow);
                    Console.WriteLine($"Number={inputNumber}  -> Result: Column={resultColumn} Row={resultRow}");
                }
            } while (inputString.ToLower() != "q");
        }

        static void CalculateArrayIndexes(int inputNumber, out int resultColumn, out int resultRow)
        {
            resultColumn = 0;
            resultRow = 0;

            // value to be added when stepping from one diagonal to the next one
            var addValue = 1;
            // first and last value in a diagonal
            var firstValueOfDiagonal = 1;
            var lastValueOfDiagonal = 1;

            var continueSearch = true;
            while (continueSearch)
            {
                // check if given number is on this diagonal
                if (  inputNumber >= firstValueOfDiagonal 
                    && inputNumber <= lastValueOfDiagonal)
                {
                    // calculate the index values and terminate loop
                    resultColumn = lastValueOfDiagonal - inputNumber;
                    resultRow = inputNumber - firstValueOfDiagonal;
                    continueSearch = false;
                }
                else
                {
                    // step to next diagonal
                    firstValueOfDiagonal += addValue;
                    lastValueOfDiagonal += addValue + 1;
                    addValue++;
                }
            }
        }
    }
}
