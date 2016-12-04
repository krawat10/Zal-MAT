using System.Collections.Generic;
using System.Text;


namespace Projekt
{
    public static class ToThePower
    {   
        //Klasa odpowiedzialna za robienie znaku do potęgi
        private static readonly string superscripts = @"⁰¹²³⁴⁵⁶⁷⁸⁹";


        public static string ToSuperscriptNumber(this int @this)
        {
            var sb = new StringBuilder();
            Stack<byte> digits = new Stack<byte>();

            do
            {
                var digit = (byte)(@this % 10);
                digits.Push(digit);
                @this /= 10;
            } while (@this != 0);

            while (digits.Count > 0)
            {
                var digit = digits.Pop();
                sb.Append(superscripts[digit]);
            }

            return sb.ToString();
        }
    }
}
