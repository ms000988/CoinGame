using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coingame
{
    class Program
    {
        static void Main(string[] args)
        {

           
            //coin variable is how much time the user want to play 
            color("You have 10 coins:", "Gray");
            int balance = 10;
            bool retry = true;
            string[] sac1 = buildArray(80, 60, 50, 60);
            string[] sac2 = buildArray(80, 80, 20, 20);
            string[] sac3 = buildArray(50,50,250,350);

            Random randNum = new Random();
            Random randNum2 = new Random();
            Random randNum3 = new Random();
            //start of bet
            while (retry)
            {
                color("Please insert your bet amount between 1 and "+balance, "Black");
                Console.WriteLine();
                int Coin = int.Parse(Console.ReadLine());
                if (Coin <= balance)
                {

                    color("Your bet amount is : "+Coin, "DarkGray");
                    Console.WriteLine();
                    for (int i = 0; i < Coin; i++)
                    {


                        string message = "";
                        string type = "White";
                        int x1 = randNum.Next(0, sac1.Length);
                        int x2 = randNum.Next(0, sac2.Length);
                        int x3 = randNum.Next(0, sac3.Length);
                        string first = sac1[x1];
                        string second = sac2[x2];
                        string third = sac3[x3];
                        color((i + 1).ToString()+" ", "Gray");
                        color(first, first);
                        color(second, second);
                        color(third, third);
                        

                        if (first == second && second == third)
                        {
                            message = " ----> 2 coins";
                            type = "Green";
                            balance += 2;
                        }
                        else if (first == second || first == third || second == third)
                        {
                            message = "----> Re-try";
                            type = "Yellow";
                        }
                        else
                        {
                            message = "----> no prize";
                            type = "Red";
                            balance -= 1;
                        }

                        color(message, type);
                        Console.WriteLine();
                        color("Your balance is : ", "Black");
                        color(balance.ToString() + " coin", "Gray");
                       

                        Console.WriteLine();
                    }
                    if (balance <= 0)
                    {
                        color("You are out of coins !", "Red");
                        retry = false;
                        break;
                    }
                    color("Do you want to continue ? ", "white");
                    color("y", "Green");
                    color("n", "Red");
                    if (Console.ReadLine() == "y")
                    {
                        retry = true;
                    }
                    else
                    {
                        retry = false;
                        break;
                    }

                }

                else
                {
                    color("You don't have enough balance to play :", "Red");
                    Console.WriteLine();
                    retry = true;
                }
            }

            Console.ReadLine();


        }
        //this methode fill the arrays with values 
        static string[] buildArray(int r, int g, int b, int y)
        {
            int x = r + g + b + y;
            string[] Ar = new string[x];

            for (int i = 0; i < x;)
            {
                if (r != 0)
                {
                    Ar[i] = "Red";
                    i += 1;
                    r -= 1;
                }
                if (g != 0)
                {
                    Ar[i] = "Green";
                    i += 1;
                    g -= 1;
                }
                if (b != 0)
                {
                    Ar[i] = "Blue";
                    i += 1;
                    b -= 1;
                }
                if (y != 0)
                {
                    Ar[i] = "Yellow";
                    i += 1;
                    y -= 1;
                }
            }

            return Ar;
        }
        //this methode to color the output messages
        static void color(string message, string type)
        {
            switch (type)
            {
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case "DarkGray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "Black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }
            Console.Write(message + " ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }
    }
}
