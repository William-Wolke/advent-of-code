using System.IO;
using System.Text.RegularExpressions;

namespace Name
{
    class Program
    {
        static void Main()
        {
            Part1();
        }
        static void Part1()
        {
            String? line;
            MatchCollection matches;
            MatchCollection numbers;
            Int32 left_num;
            Int32 right_num;
            Int32 tot_sum = 0;
            Regex regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
            Regex regex2 = new Regex(@"\d{1,3}");
            StreamReader sr = new StreamReader("./input.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    numbers = regex2.Matches(match.Value);
                    left_num = Int32.Parse(numbers[0].Value);
                    right_num = Int32.Parse(numbers[1].Value);
                    tot_sum += left_num * right_num;
                }
                line = sr.ReadLine();
            }
            sr.Close();
            Console.WriteLine(tot_sum);
            Console.ReadLine();
        }
    }
}

