
namespace NumberConverterLib
{
    interface INumberConverter
    {
        long FromNumberWithBase(string value, int baseValue);

        string ToNumberWithBase(long value, int baseValue);
    }
}
