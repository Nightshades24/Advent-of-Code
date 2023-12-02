namespace AdventOfCode._2023
{
    public class Day2
    {
        static public int Part1(string[] input)
        {
            int output = 0;

            int[] bag = new int[3] {12, 13, 14};

            for (int i = 0; i < input.Length; i++)
            {
                string gameId = input[i].Split(':')[0].Split(' ')[1];
                string game = input[i].Split(':')[1];

                string[] games = game.Split(';');

                bool possible = true;

                for (int j = 0; j < games.Length; j++)
                {
                    string[] colors = games[j].Split(',');
                    bag[0] = 12;
                    bag[1] = 13;
                    bag[2] = 14;

                    for (int k = 0; k < colors.Length; k++)
                    {
                        string color = colors[k].Split(' ')[2];

                        switch (color)
                        {
                            case "red":
                                bag[0] -= int.Parse(colors[k].Split(' ')[1]);
                                break;
                            case "green":
                                bag[1] -= int.Parse(colors[k].Split(' ')[1]);
                                break;
                            case "blue":
                                bag[2] -= int.Parse(colors[k].Split(' ')[1]);
                                break;
                        }
                    }


                    if (bag[0] < 0 || bag[1] < 0 || bag[2] < 0)
                    {
                        possible = false;
                        break;
                    }
                }

                if (possible)
                {
                    output += int.Parse(gameId);
                }
            }

            return output;
        }

        static public int Part2(string[] input)
        {
            int output = 0;

            int[] bag = new int[3];

            for (int i = 0; i < input.Length; i++)
            {
                string game = input[i].Split(':')[1];

                string[] games = game.Split(';');

                int bag0 = 0;
                int bag1 = 0;
                int bag2 = 0;

                for (int j = 0; j < games.Length; j++)
                {
                    string[] colors = games[j].Split(',');
                    bag[0] = 0;
                    bag[1] = 0;
                    bag[2] = 0;

                    for (int k = 0; k < colors.Length; k++)
                    {
                        string color = colors[k].Split(' ')[2];

                        switch (color)
                        {
                            case "red":
                                bag[0] += int.Parse(colors[k].Split(' ')[1]);
                                break;
                            case "green":
                                bag[1] += int.Parse(colors[k].Split(' ')[1]);
                                break;
                            case "blue":
                                bag[2] += int.Parse(colors[k].Split(' ')[1]);
                                break;
                        }
                    }

                    if (bag[0] > bag0)
                    {
                        bag0 = bag[0];
                    }

                    if (bag[1] > bag1)
                    {
                        bag1 = bag[1];
                    }

                    if (bag[2] > bag2)
                    {
                        bag2 = bag[2];
                    }
                }

                output += bag0 * bag1 * bag2;
            }

            return output;
        }
    }
}
