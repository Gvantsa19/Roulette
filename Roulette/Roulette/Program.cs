using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 1000;
            double bet;

            Console.WriteLine($"Your balance is { balance}");


            while (balance != 0)
            {
                Console.WriteLine("Please enter your bet");
                bet = double.Parse(Console.ReadLine());
                if (bet > balance || bet <= 0 || bet > 60)
                {
                    Console.WriteLine("Max bet is 60, Please enter a valid bet");
                }

                string choice = ChooseOne();
                balance = PlaceBet(choice, balance, bet);

                Console.WriteLine($"Now your balance is { balance}");
                if (balance != 0)
                {
                    Console.WriteLine("Do you want to continue ? Y/N");
                    if (Console.ReadLine().Equals("n"))
                    {
                        Console.WriteLine("Game over");
                    }
                }
            }

            if (balance == 0)
            {
                Console.WriteLine("You lost, Game over");
            }

            string ChooseOne()
            {
                Console.WriteLine("Select one: ");
                Console.WriteLine("1) Black or Red");
                Console.WriteLine("2) Odd or Even");
                Console.WriteLine("3) Single number");
                Console.WriteLine("4) 1st 12, 2nd 12, 3rd 12: (1-12)/(13-24)/(25-36)");
                Console.WriteLine("");

                return Console.ReadLine();
            }

            double PlaceBet(string choice, double balance, double bet)
            {
                int enteredNumber;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Red or Black");
                        balance += Spin("1", Console.ReadLine(), bet);
                        break;
                    case "2":
                        Console.WriteLine("Odd or Even");
                        balance += Spin("2", Console.ReadLine(), bet);
                        break;
                    case "3":
                        Console.WriteLine("Enter number");
                        do
                        {
                            enteredNumber = int.Parse(Console.ReadLine());
                            if (enteredNumber < 0 || enteredNumber > 36)
                            {
                                Console.WriteLine("Enter valid number");
                            }
                        } while (enteredNumber < 0 || enteredNumber > 36);
                        balance += Spin("3", Console.ReadLine(), bet);
                        break;
                    case "4":
                        Console.WriteLine("First, Second or Third");
                        balance += Spin("4", Console.ReadLine(), bet);
                        break;
                    case "5":
                        Console.WriteLine("Game over");
                        break;
                }
                return balance;
            }

            double Spin(string cases, string input, double bet)
            {
                double winningA = 0;
                int selectedNumber = WinningNumb();

                if (selectedNumber == -1)
                {
                    Console.WriteLine("winning number is 0");
                }
                else
                {
                    Console.WriteLine($"winning number is { selectedNumber}");
                }

                if (input.Equals(00))
                {
                    input.Replace("00", "-1");
                }

                switch (cases)
                {
                    case "1":
                        if (selectedNumber == 0 || selectedNumber == -1)
                        {
                            winningA = 0;
                        }
                        else if ((input.Equals("red") && selectedNumber % 2 == 0) || (input.Equals("black") && selectedNumber % 2 != 0))
                        {
                            winningA = bet + bet;
                        }
                        break;
                    case "2":
                        if (selectedNumber == 0 || selectedNumber == -1)
                        {
                            winningA = 0;
                        }
                        else if ((input.Equals("even") && selectedNumber % 2 == 0) || (input.Equals("odd") && selectedNumber % 2 != 0))
                        {
                            winningA = bet + bet;
                        }
                        break;
                    case "3":
                        if (selectedNumber == int.Parse(input))
                        {
                            winningA = bet + 35 * bet;
                        }
                        break;
                    case "4":
                        if (input.Equals("first") && selectedNumber > 0 && selectedNumber < 13)
                        {
                            winningA = bet + 2 * bet;
                        }
                        else if (input.Equals("second") && selectedNumber > 12 && selectedNumber < 25)
                        {
                            winningA = bet + 2 * bet;
                        }
                        else if (input.Equals("third") && selectedNumber > 24 && selectedNumber < 36)
                        {
                            winningA = bet + 2 * bet;
                        }
                        break;
                }
                if (winningA > 0)
                {
                    Console.WriteLine($"You won { winningA}");
                }
                else
                {
                    Console.WriteLine("You lost");
                }
                return winningA;

            }

            int WinningNumb()
            {
                Random r = new Random();
                return r.Next(0, 36);
            }
        }
    }
}
