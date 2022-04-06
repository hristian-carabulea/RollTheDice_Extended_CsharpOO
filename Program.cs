using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollTheDice
{
    class Program
    {
        /// <summary>
        /// Demonstrates rolling and using two dice
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main()
        {
            // initialize random number generator
            RandomNumberGenerator.Initialize();

            // create two dice
            Die playerDie1 = new Die();
            Die playerDie2 = new Die();

            Die computerDie1 = new Die();
            Die computerDie2 = new Die();

            int sumPlayer, sumComputer, playerPoints=0, computerPoints=0;
            string winnerMessage;

            Console.Write("\nPress any key to roll the dice or 'x' to end the program. Sum of dice with same value is doubled: ");

            //check if the entered key is x or X. If yes, stop the game, else keep playing.
            while (Console.ReadKey().Key != ConsoleKey.X)
            {

                // tell the dice to roll themselves
                computerDie1.Roll();
                computerDie2.Roll();

                // roll player dice
                playerDie1.Roll();
                playerDie2.Roll();

                //calculate the sum of player's two dice. Doubles are being doubled.
                if (playerDie1.TopSide == playerDie2.TopSide)
                {
                    sumPlayer = (playerDie1.TopSide + playerDie2.TopSide) * 2;
                }
                else
                {
                    sumPlayer = playerDie1.TopSide + playerDie2.TopSide;
                }
                //display the dice values the player rolled
                Console.WriteLine("\n==> You rolled... " + playerDie1.TopSide + ":" + playerDie2.TopSide);

                System.Threading.Thread.Sleep(1000);

                // roll computer dice
                computerDie1.Roll();
                computerDie2.Roll();

                //calculate the sum of computer's two dice. Doubles are being doubled.
                if (computerDie1.TopSide == computerDie2.TopSide)
                {
                    sumComputer = (computerDie1.TopSide + computerDie2.TopSide) * 2;
                }
                else
                {
                    sumComputer = computerDie1.TopSide + computerDie2.TopSide;
                }
                //display the dice values the computer rolled
                Console.WriteLine("==> Computer rolled... " + computerDie1.TopSide + ":" + computerDie2.TopSide);

                //check who scored more points, and display who won this roll
                if (sumPlayer > sumComputer)
                {
                    playerPoints++;
                    Console.WriteLine("====> You win this round.");
                }
                else if (sumPlayer < sumComputer)
                {
                    computerPoints++;
                    Console.WriteLine("====> Computer wins this round.");
                }
                else
                {
                    Console.WriteLine("====> Nobody won this round");
                }

                // request to have player stop or continue the game
                Console.WriteLine();
                Console.Write("Press any key to roll the dice or 'x' to end the program. Sum of dice with same value is doubled: ");

            }

            //display the final results
            Console.WriteLine("\n==============");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("\n==>You won: " + playerPoints + " rounds");
            Console.WriteLine("==>Computer won: " + computerPoints + " rounds");

            if (playerPoints < computerPoints)
            {
                winnerMessage = "====>Computer wins the game!";
            }
            else if (computerPoints < playerPoints)
            {
                winnerMessage = "====>You win the game!";
            }
            else
                winnerMessage = "====>Nobody won the game...";
            //string winnerMessage = playerPoints < enemyPoints ? "Computer wins" : "You win"; //cannot use this statement when both players have same score
            Console.WriteLine(winnerMessage);
            Console.ReadKey();

        }
    }
}
