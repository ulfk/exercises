
namespace ShuffleCards
{
    using System.Collections.Generic;
    using System.IO;

    class CardFileFactory
    {
        private static readonly string CardFolder = "cards";
        private static readonly int NumberOfCards = 56;
        private static readonly int[] ExcludedCardNumbers = { 10, 24, 38, 52 };
        private static List<string> CardFilenames = null;
        public static readonly int ImageWidth = 79;
        public static readonly int ImageHeight = 123;
        public static readonly int ImageMargin = 5;
        public static readonly int RowLength = 13;

        /// <summary>
        /// Returns a list containing filenames of all cards. 
        /// </summary>
        /// <returns>
        /// List of string containing the filenames of all cards.
        /// </returns>
        public static List<string> GetFilenames()
        {
            if(CardFilenames == null)
            {
                CardFilenames = new List<string>();
                for (var idx = 0; idx < NumberOfCards; idx++)
                {
                    if(IsValidCardNumber(idx))
                    {
                        CardFilenames.Add(GetCardFilenameByNumber(idx));
                    }
                }
            }

            return CardFilenames;
        }

        public static int Count()
        {
            return NumberOfCards - ExcludedCardNumbers.Length;
        }

        private static bool IsValidCardNumber(int cardNumber)
        {
            var isValidCardNumber = true;
            foreach(var excludedNumber in ExcludedCardNumbers)
            {
                isValidCardNumber = isValidCardNumber && (cardNumber != excludedNumber);
            }

            return isValidCardNumber;
        }

        private static string GetCardFilenameByNumber(int cardNumber)
        {
            return Path.Combine(CardFolder, $"{cardNumber:00}.png");
        }
    }
}
