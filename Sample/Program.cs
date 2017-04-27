using System;
using System.Text;
using System.Text.RegularExpressions;
using Tools;
using Tools.libs;
using _ = System.Console;

namespace Sample
{
    internal class Program
    {
        private static void Main()
        {
            var loop = true;
            var value = new StringBuilder().Clear();
            _.Clear();
            _.WriteLine("Convertir un nombre en chiffre romain.\nAppuyer sur [Echap] pour sortir");

            _.Write(@"Saisir un nombre puis [Entrée] ? ");

            while (loop)
            {
                var readKey = _.ReadKey(true);
                switch (readKey.Key)
                {
                    case ConsoleKey.Enter: // Valide la saisie
                        if (value.Length > 0)
                        {
                            ConversionToRoman(value.ToString());
                            value.Clear();
                            _.Write("Saisir un nombre puis [Entrée] ? ");
                        }
                        break;
                    case ConsoleKey.Backspace: // Efface le nombre saisi
                        if (value.Length > 0)
                        {
                            value.Remove(value.Length - 1, 1);
                            _.Write("\b \b");
                        }
                        break;
                    case ConsoleKey.Escape: // Sortir du programme
                        loop = false;
                        break;
                    default:
                        if (Regex.IsMatch(readKey.KeyChar.ToString(), @"^\d+$"))
                        {
                            value.Append(readKey.KeyChar);
                            if (int.Parse(value.ToString()) > Roman.Max) value.Remove(value.Length - 1, 1);
                            else _.Write(readKey.KeyChar);
                        }
                        break;
                }
            }
        }

        private static void ConversionToRoman(string value)
        {
            try
            {
                // Conversion en nombre romain
                _.WriteLine("\nEn chiffre romain {0} s'écrit : {1}", value,
                    Conversion.ToRoman(value));
            }
            catch (Exception ex)
            {
                // Message d'erreur
                _.WriteLine("\nErreur : {0}", ex.Message);
            }
        }
    }
}