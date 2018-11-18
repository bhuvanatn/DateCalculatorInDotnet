using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DateCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter start date dd/MM/yyyy format:");
            string startdate = MatchReg(Console.ReadLine());

            Console.WriteLine("Enter end date dd/MM/yyyy format:");
            string enddate = MatchReg(Console.ReadLine());

            long days = ToJulian(enddate) - ToJulian(startdate);
            long Totaldays = days - 1;
            Console.WriteLine("Total Days difference excluding first and last day: = " + Totaldays);
            Console.ReadKey();
        }
        public static string MatchReg(string date)
        {
            Regex regex = new Regex(@"(0[1-9]|[12][0-9]|[3][01])[\- \/.](0[1-9]|1[012])[\- \/.]((19|2[0-9])[0-9][1-9])");
            bool isValid = regex.IsMatch(date.Trim());

            if (!isValid)
            {
                Console.WriteLine("Invalid Date.Please Enter correct format in dd/MM/yyyy with '/ . - space'");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return date;
        }
        public static long ToJulian(string mdy)
        {
            var split = mdy.Split('/', '.', '-', ' ');
            int month = int.Parse(split[1]);
            int day = int.Parse(split[0]);
            int year = int.Parse(split[2]);
            if (month < 3)
            {
                month = month + 12;
                year = year - 1;
            }
            return day + (153 * month - 457) / 5 + 365 * year + (year / 4) - (year / 100) + (year / 400) + 1721119;
        }


    }
}
