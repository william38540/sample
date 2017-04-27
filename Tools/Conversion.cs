using System;
using System.Text.RegularExpressions;
using Tools.libs;

namespace Tools
{
    public static class Conversion
    {
        public static string ToRoman(string value)
        {   // Utilisation des expressions régulières
            if (Regex.IsMatch(value, @"^\d+$") && value.Length <= 4)
                return ToRoman(int.Parse(value));
            throw new FormatException("Format non supporté");
        }

        public static string ToRoman(int number)
        {
            if (number <= Roman.Max)
                return Roman.ToString(number);
            throw new FormatException("Nombre supérieur à 4999");
        }
    }
}