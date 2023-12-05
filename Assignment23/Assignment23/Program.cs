using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment23
{
    public delegate void SpinDelegate(ref int energyLev, ref int winProb);
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Lucky Spin Game!");

            Console.Write("Enter Your Name: ");
            string playerName = Console.ReadLine();

            int energyLev = 1;
            int winProb = 100;
            int spinsLeft = 5;

            SpinDelegate spinDelegate = Spin;

            for (int spinNum = 1; spinNum <= 10; spinNum++)
            {
                if (spinsLeft > 0)
                {
                    Console.WriteLine($"Spin {spinNum}:");
                    spinDelegate.Invoke(ref energyLev, ref winProb);
                    Console.WriteLine($"Energy Level: {energyLev}, Winning Probability: {winProb}");
                    spinsLeft--;
                }
                else
                {
                    Console.WriteLine("No more spins left. Game over!");
                    break;
                }
            }

            DetermineWinner(energyLev, winProb);
            Console.ReadKey();
        }

        static void Spin(ref int energyLev, ref int winProb)
        {
            switch (energyLev)
            {
                case 1:
                    energyLev += 1;
                    winProb += 10;
                    break;
                case 2:
                    energyLev += 2;
                    winProb += 20;
                    break;
                case 3:
                    energyLev -= 3;
                    winProb -= 30;
                    break;
                case 4:
                    energyLev += 4;
                    winProb += 40;
                    break;
                case 5:
                    energyLev += 5;
                    winProb += 50;
                    break;
                case 6:
                    energyLev -= 1;
                    winProb -= 60;
                    break;
                case 7:
                    energyLev += 1;
                    winProb += 70;
                    break;
                case 8:
                    energyLev -= 2;
                    winProb -= 20;
                    break;
                case 9:
                    energyLev -= 3;
                    winProb -= 30;
                    break;
                case 10:
                    energyLev += 10;
                    winProb += 100;
                    break;
            }
        }

        static void DetermineWinner(int energyLev, int winProb)
        {
            Console.WriteLine("\nGame Over! Results:");

            if (energyLev >= 4 && winProb > 60)
            {
                Console.WriteLine("Winner!");
            }
            else if (energyLev >= 1 && winProb > 50)
            {
                Console.WriteLine("Runner Up!");
            }
            else
            {
                Console.WriteLine("Loser!");
            }
        }
    }
}
