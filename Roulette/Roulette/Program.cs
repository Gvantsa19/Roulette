using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 1000;
            double bet;

            Console.WriteLine("Your balance is: " + balance);


            while (balance != 0)
            {
                Console.WriteLine("Enter Yourbet");

                    bet = double.Parse(Console.ReadLine());
                    if (bet <= 0 || bet > balance)
                    {
                        Console.WriteLine("Please Enter a valid bet amount");
                    }

                string choice = DisplayMenu();

                balance = PlaceBet(choice, balance, bet);

                Console.WriteLine("Updated balance is: " + balance);
                if (balance != 0)
                {
                    Console.WriteLine("Do you want to continue playing? (Y/N)");
                    if (Console.ReadLine().Equals("N"))
                    {
                        Console.WriteLine("*******************");
                        Console.WriteLine("     Game Over"); 
                        Console.WriteLine("*******************");
                    }
                }
            }

            if (balance == 0)
            {
                Console.WriteLine("*******************");
                Console.WriteLine("You Are Loser");
                Console.WriteLine("*******************");
            }
        }
        private static string DisplayMenu()
        {
            Console.WriteLine("Select a bet:");
            Console.WriteLine("1) Red/Black");
            Console.WriteLine("2) Odd/Even");
            Console.WriteLine("3) Single number");
            Console.WriteLine("4) 1st 12, 2nd 12, 3rd 12: (1-12)/(13-24)/(25-36)");
            Console.WriteLine("5) Low (1-18) / High (19-36)");

            return Console.ReadLine();
        }

        private static double PlaceBet(string choice, double balance, double bet)
        {
            int enteredNumber;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\r\nType Red or Black: ");
                    balance += SpinRoulette("1", Console.ReadLine(), bet);
                    break;
                case "2":
                    Console.WriteLine("\r\nType Odd or Even: ");
                    balance += SpinRoulette("2", Console.ReadLine(), bet);
                    break;
                case "3":
                    Console.WriteLine("\r\nEnter a number: ");
                    do
                    {
                        enteredNumber = int.Parse(Console.ReadLine());
                        if (enteredNumber < 0 || enteredNumber > 36)
                        {
                            Console.WriteLine("\r\nEnter a number between 00 and 36: ");
                        }
                    } while (enteredNumber < 0 || enteredNumber > 36);

                    balance += SpinRoulette("3", enteredNumber.ToString(), bet);
                    break;
                case "4":
                    Console.WriteLine("\r\nType First or Second or Third: ");
                    balance += SpinRoulette("4", Console.ReadLine(), bet);
                    break;
                case "5":
                    Console.WriteLine("\r\nType Low or High: ");
                    balance += SpinRoulette("5", Console.ReadLine(), bet);
                    break;
                case "6":
                    Console.WriteLine("\r\n*******************");
                    Console.WriteLine("\r\n     Game Over"); 
                    Console.WriteLine("\r\n*******************");
                    Environment.Exit(0);
                    break;
            }
            return balance;
        }

        private static double SpinRoulette(string cases, string input, double bet)
        {
            double winningAmount = 0;

            int selectedNumber = WinningNumber();

            if (selectedNumber == -1)
                Console.WriteLine("\r\nWinning number is: 00");
            else
                Console.WriteLine("\r\nWinning number is: " + selectedNumber);

            if (input.Equals("00"))
            {
                input.Replace("00", "-1");
            }

            switch (cases)
            {
                case "1":
                    if (selectedNumber == 0 || selectedNumber == -1)
                    {
                        winningAmount = 0;
                    }
                    else if ((input.Equals("red") && selectedNumber % 2 == 0) || (input.Equals("black") && selectedNumber % 2 != 0))
                    {
                        winningAmount = bet + bet;
                    }
                    break;
                case "2":
                    if (selectedNumber == 0 || selectedNumber == -1)
                    {
                        winningAmount = 0;
                    }
                    else if ((input.Equals("even") && selectedNumber % 2 == 0) || (input.Equals("odd") && selectedNumber % 2 != 0))
                    {
                        winningAmount = bet + bet;
                    }
                    break;
                case "3":
                    if (selectedNumber == int.Parse(input))
                    {
                        winningAmount = bet + 35 * bet;
                    }
                    break;
                case "4":
                    if (input.Equals("first") && selectedNumber > 0 && selectedNumber < 13)
                    {
                        winningAmount = bet + 2 * bet;
                    }
                    else if (input.Equals("second") && selectedNumber > 12 && selectedNumber < 25)
                    {
                        winningAmount = bet + 2 * bet;
                    }
                    else if (input.Equals("third") && selectedNumber > 24 && selectedNumber < 37)
                    {
                        winningAmount = bet + 2 * bet;
                    }
                    break;
                case "5":
                    if (input.Equals("low") && selectedNumber > 0 && selectedNumber < 19)
                    {
                        winningAmount = bet + bet;
                    }
                    else if (input.Equals("high") && selectedNumber > 18 && selectedNumber < 37)
                    {
                        winningAmount = bet + bet;
                    }
                    break;
            }
            if (winningAmount > 0)
                Console.WriteLine("\r\nCongratulations! You Won: $" + winningAmount);
            else
                Console.WriteLine("\r\nYou Lost: $" + bet);

            return winningAmount;
        }

        private static int WinningNumber()
        {
            Random r = new Random();
            return r.Next(0, 36);
        }
    }
}
