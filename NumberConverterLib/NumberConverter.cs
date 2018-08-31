using System;
using System.IO;
using System.Linq;
using System.Text;

namespace NumberConverterLib
{
    public class NumberConverter : INumberConverter
    {
        private const string ValidChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public long FromNumberWithBase(string value, int baseValue)
        {
            ValidateStringValue(value);
            ValidateBase(baseValue);
            var length = value.Length;
            return value.Select((c, idx) => GetCharValueOnIndex(c, baseValue, length - (idx + 1))).Sum(); ;
        }

        private void ValidateBase(int baseValue)
        {
            if (baseValue <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(baseValue), "Die Basis darf nicht kleiner als 2 sein!");
            }
            if (baseValue > ValidChars.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(baseValue), $"Die Basis darf nicht groesser als {ValidChars.Length} sein!");
            }
        }

        private void ValidateStringValue(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Der Wert darf nicht NULL sein");
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Der Wert darf nicht leer sein", nameof(value));
            }
        }

        private long GetCharValueOnIndex(char chr, int baseValue, int index)
        {
            return GetCharValue(chr, baseValue) * LongPower(baseValue, index);
        }

        private long GetCharValue(char chr, int baseValue)
        {
            var result = ValidChars.IndexOf($"{chr}", StringComparison.Ordinal);
            if (result < 0 || result >= baseValue)
            {
                throw new InvalidDataException($"Ungültiges Zeichen '{chr}' für die Basis {baseValue}!");
            }

            return (long)result;
        }

        private long LongPower(long value, long power)
        {
            long result = 1;
            for (long idx = power; idx > 0; idx--)
            {
                result *= value;
            }

            return result;
        }

        private void ValidateLongValue(long value)
        {
            if (value < 0)
            {
                throw new ArgumentException("value must be greater or equal zero", nameof(value));
            }
        }

        public string ToNumberWithBase(long value, int baseValue)
        {
            ValidateBase(baseValue);
            ValidateLongValue(value);
            var result = string.Empty;
            var valueToConvert = value;
            do
            {
                var digit = valueToConvert % baseValue;
                var chr = DigitToChar(digit);
                result = chr + result;
                valueToConvert = (valueToConvert - digit) / baseValue;
            } while (valueToConvert > 0L);

            return result;
        }

        private char DigitToChar(long digit)
        {
            if (digit >= ValidChars.Length)
            {
                throw new InvalidDataException($"Cannot convert {digit} to char");
            }

            return ValidChars[(int)digit];
        }
    }
}
