using AdventOfCode._2023;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main()
        {
            string[] input = GetInput(4, false).ToArray();

            Console.WriteLine(Day4.Part2(input));
            Console.ReadLine();
        }

        public static List<string> GetInput(int day, bool test)
        {
            string[] textFile = test == false ? File.ReadAllLines($"../../../Input/{day}.txt") : File.ReadAllLines($"../../../Input/{day}_test.txt");
            List<string> input = new(textFile);

            return input;
        }
    }
}