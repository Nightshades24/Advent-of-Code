namespace AdventOfCode._2023
{
    public class Day3
    {
        static public int Part1(string[] input)
        {
            int output = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];

                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];

                    if (char.IsDigit(c))
                    {
                        // Check if char has something else other than a dot or a number (0-9) next to it horizontally, vertically or diagonally
                        if (
                            (j - 1 >= 0 && line[j - 1] != '.' && !char.IsDigit(line[j - 1])) || 
                            (j + 1 < line.Length && line[j + 1] != '.' && !char.IsDigit(line[j + 1])) || 
                            (i - 1 >= 0 && input[i - 1][j] != '.' && !char.IsDigit(input[i - 1][j])) || 
                            (i + 1 < input.Length && input[i + 1][j] != '.' && !char.IsDigit(input[i + 1][j])) ||
                            (i - 1 >= 0 && j - 1 >= 0 && input[i - 1][j - 1] != '.' && !char.IsDigit(input[i - 1][j - 1])) ||
                            (i - 1 >= 0 && j + 1 < line.Length && input[i - 1][j + 1] != '.' && !char.IsDigit(input[i - 1][j + 1])) ||
                            (i + 1 < input.Length && j - 1 >= 0 && input[i + 1][j - 1] != '.' && !char.IsDigit(input[i + 1][j - 1])) ||
                            (i + 1 < input.Length && j + 1 < line.Length && input[i + 1][j + 1] != '.' && !char.IsDigit(input[i + 1][j + 1]))
                        )
                        {
                            // Find all numbers in the line next to the current char
                            string numbers = c.ToString();

                            for (int x1 = j - 1; x1 >= 0; x1--)
                            {
                                if (char.IsDigit(line[x1]))
                                {
                                    numbers = line[x1] + numbers;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            int lastIndex = j;

                            for (int x2 = j + 1; x2 < line.Length; x2++)
                            {
                                if (char.IsDigit(line[x2]))
                                {
                                    numbers += line[x2];
                                    lastIndex = x2;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            j = lastIndex;
                            output += int.Parse(numbers);
                        }
                    }

                }
            }

            return output;
        }

        static public int Part2(string[] input)
        {
            int output = 0;

            Dictionary<string, List<string>> result = new();

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];

                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];

                    if (char.IsDigit(c))
                    {
                        // Check if char has something else other than a dot or a number (0-9) next to it horizontally, vertically or diagonally
                        if (
                            (j - 1 >= 0 && line[j - 1] == '*') ||
                            (j + 1 < line.Length && line[j + 1] == '*') ||
                            (i - 1 >= 0 && input[i - 1][j] == '*') ||
                            (i + 1 < input.Length && input[i + 1][j] == '*') ||
                            (i - 1 >= 0 && j - 1 >= 0 && input[i - 1][j - 1] == '*') ||
                            (i - 1 >= 0 && j + 1 < line.Length && input[i - 1][j + 1] == '*') ||
                            (i + 1 < input.Length && j - 1 >= 0 && input[i + 1][j - 1] == '*') ||
                            (i + 1 < input.Length && j + 1 < line.Length && input[i + 1][j + 1] == '*')
                        )
                        {
                            List<string> coords = new();
                            if (j - 1 >= 0 && line[j - 1] == '*')
                            {
                                coords.Add($"{i},{j - 1}");
                            }
                            if (j + 1 < line.Length && line[j + 1] == '*')
                            {
                                coords.Add($"{i},{j + 1}");
                            }
                            if (i - 1 >= 0 && input[i - 1][j] == '*')
                            {
                                coords.Add($"{i - 1},{j}");
                            }
                            if (i + 1 < input.Length && input[i + 1][j] == '*')
                            {
                                coords.Add($"{i + 1},{j}");
                            }
                            if (i - 1 >= 0 && j - 1 >= 0 && input[i - 1][j - 1] == '*')
                            {
                                coords.Add($"{i - 1},{j - 1}");
                            }
                            if (i - 1 >= 0 && j + 1 < line.Length && input[i - 1][j + 1] == '*')
                            {
                                coords.Add($"{i - 1},{j + 1}");
                            }
                            if (i + 1 < input.Length && j - 1 >= 0 && input[i + 1][j - 1] == '*')
                            {
                                coords.Add($"{i + 1},{j - 1}");
                            }
                            if (i + 1 < input.Length && j + 1 < line.Length && input[i + 1][j + 1] == '*')
                            {
                                coords.Add($"{i + 1},{j + 1}");
                            }

                            // Find all numbers in the line next to the current char
                            string numbers = c.ToString();

                            for (int x1 = j - 1; x1 >= 0; x1--)
                            {
                                if (char.IsDigit(line[x1]))
                                {
                                    numbers = line[x1] + numbers;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            int lastIndex = j;

                            for (int x2 = j + 1; x2 < line.Length; x2++)
                            {
                                if (char.IsDigit(line[x2]))
                                {
                                    numbers += line[x2];
                                    lastIndex = x2;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            j = lastIndex;

                            // Add to dictionary with the key being the coords and the value being the numbers
                            foreach (string coord in coords)
                            {
                                if (result.ContainsKey(coord))
                                {
                                    result[coord].Add(numbers);
                                }
                                else
                                {
                                    result.Add(coord, new List<string> { numbers });
                                }
                            }
                        }
                    }
                }
            }

            // For each coords in the dictionary, multiply all the numbers in the list
            foreach (KeyValuePair<string, List<string>> item in result)
            {
                if (item.Value.Count != 2)
                {
                    continue;
                }

                int total = 1;

                foreach (string number in item.Value)
                {
                    total *= int.Parse(number);
                }

                output += total;
            }

            return output;
        }
    }
}
