using System;
using System.Collections.Generic;
using System.Linq;

namespace Tools.libs
{
    public class Roman
    {
        private const short m_Min = 1;
        private const short m_Max = 4999;

        public static int Min => m_Min;
        public static int Max => m_Max;

        /// <summary>Convert numeric number to roman.
        /// <para>number to convert</para>
        /// </summary>
        public static string ToString(int number)
        {
            try
            {
                if (number > Max || number < Min)
                    throw new FormatException("Doit être compris entre 1 et 4999");

                // Dictionnaire
                var romanDic = new Dictionary<int, List<string>>
                {
                    {0, new List<string> {string.Empty, "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"}},
                    {1, new List<string> {string.Empty, "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"}},
                    {2, new List<string> {string.Empty, "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"}},
                    {3, new List<string> {string.Empty, "M", "MM", "MMM", "MMMM"}}
                };

                // Séquence fractionnée en tableau et rangée inverse
                var splitArray = number.ToString().Reverse().ToArray();
                var i = splitArray.Length;
                var romanConvert = string.Empty;
                //Expressions de requête LINQ
                while (i-- > 0)
                    romanConvert +=
                        (from roman in romanDic
                         where roman.Key == i
                         select roman.Value[int.Parse(splitArray[i].ToString())])
                        .FirstOrDefault();

                return romanConvert;
            }
            catch (Exception e)
            {
                throw new FormatException(e.Message);
            }
        }
    }

}