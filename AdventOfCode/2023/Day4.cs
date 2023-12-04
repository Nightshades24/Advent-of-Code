namespace AdventOfCode._2023
{
    public class Day4
    {
        static public int Part1(string[] input)
        {
            int output = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] split = input[i].Replace("  ", " ").Split(" | ");
                string[] winning = split[0].Split(' ')[2..];
                string[] numbers = split[1].Split(' ');

                int count = 0;
                foreach (string number in winning)
                {
                    if (numbers.Contains(number))
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    output += (int)Math.Pow(2, count - 1);
                }
            }

            return output;
        }

        static public int Part2(string[] input)
        {
            List<string> cards = input.ToList();

            for (int i = 0; i < cards.Count; i++)
            {
                string[] split = cards[i].Replace("   ", " ").Replace("  ", " ").Split(" | ");
                string nr = split[0].Split(' ')[1].Replace(":", "");
                int cardNumber = int.Parse(nr);
                string[] winning = split[0].Split(' ')[2..];
                string[] numbers = split[1].Split(' ');

                int count = 0;
                foreach (string number in winning)
                {
                    if (numbers.Contains(number))
                    {
                        count++;
                    }
                }

                for (int j = 0; j < count; j++)
                {
                    cards.Add(input[cardNumber + j]);
                }
            }

            return cards.Count;
        }
    }
}
