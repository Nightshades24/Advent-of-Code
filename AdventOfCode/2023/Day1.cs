namespace AdventOfCode._2023
{
    public class Day1
    {
        static public int Part1(string[] input)
        {
            int total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                // Filter al non numbers from the string
                string filtered = new(input[i].Where(char.IsDigit).ToArray());

                // Get the first number
                string firstNumber = filtered[0].ToString();

                // Get the last number
                string lastNumber = filtered[filtered.Length - 1].ToString();

                // Combine the first and last number 
                int number = int.Parse(firstNumber + lastNumber);

                // Add the number to the total
                total += number;
            }

            return total;
        }

        static public int Part2(string[] input)
        {
            int total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string output = input[i].ToLower().Replace("one", "o1e").Replace("two", "t2o").Replace("three", "t3e").Replace("four", "f4r").Replace("five", "f5e").Replace("six", "s6x").Replace("seven", "s7n").Replace("eight", "e8t").Replace("nine", "n9e");

                // Filter al non numbers from the string
                string filtered = new(output.Where(char.IsDigit).ToArray());

                // Get the first number
                string firstNumber = filtered[0].ToString();

                // Get the last number
                string lastNumber = filtered[^1].ToString();

                // Combine the first and last number 
                int number = int.Parse(firstNumber + lastNumber);

                // Add the number to the total
                total += number;
            }

            return total;
        }
    }
}
