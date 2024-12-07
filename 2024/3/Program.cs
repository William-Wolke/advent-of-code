using System.IO;
using System.Text.RegularExpressions;

namespace Name
{
    class Program
    {
        static void Main()
        {
            Part1();
            Part2();
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
        }
        static void Part2() {
            String lines = "";
            String? line;
            MatchCollection numbers;
            Int32 left_num;
            Int32 right_num;
            Int32 tot_sum = 0;
            Regex regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
            Regex regex2 = new Regex(@"\d{1,3}");
            Regex regex3 = new Regex(@"don't\(\)[\s\S]*?do\(\)");
            StreamReader sr = new StreamReader("./input.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                lines += line;
                line = sr.ReadLine();
            }
            foreach (Match match in regex3.Matches(lines))
            {
                lines = lines.Replace(match.Value, "");
            }
            foreach (Match match in regex.Matches(lines))
            {
                numbers = regex2.Matches(match.Value);
                left_num = Int32.Parse(numbers[0].Value);
                right_num = Int32.Parse(numbers[1].Value);
                tot_sum += left_num * right_num;
            }
            sr.Close();
            Console.WriteLine(tot_sum);
        }
    }
}

