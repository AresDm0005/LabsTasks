using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6_bonus
{
    class Program
    {
        // Check input is that a correct IP
        static void Main(string[] args)
        {
            string txt = Console.ReadLine();

            string pattern1 = @"^((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))(\.((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))){3}$";

            string ans = pattern1;
            bool isCorrectIP = Regex.IsMatch(txt, ans);

            Console.WriteLine(isCorrectIP ? "Yes" : "No");
        }
    }
}
