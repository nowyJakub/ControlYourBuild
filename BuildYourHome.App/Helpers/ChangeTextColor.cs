using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourHome.Helpers
{
    public static class ChangeTextColor
    {
       public static void PrintInformation(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ForegroundColor= ConsoleColor.White;
        }

        public static void PrintError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintTitleOfAction(string text)
        {
           
            int StringLengh = text.Length;
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < StringLengh; i++) 
            {
                Console.Write("--");
            }
            Console.WriteLine();
            Console.WriteLine($"{ text} ");
            for (int i = 0; i < StringLengh; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine() ;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
