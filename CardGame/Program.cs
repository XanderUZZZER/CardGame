using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardGame21;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "y";
            int AIWins = 0;
            int HumanWins = 0;
            int Draws = 0;

            while (userInput != "n")
            {
                Console.WriteLine("\nWho will start?\n\tAI - input \"0\"\n\tYou - input \"1\"");
                int start = int.Parse(Console.ReadLine());
                string FirstPlayer = (start == 1) ? "You" : "AI";
                Console.WriteLine("\nNew game. {0} will receive cards first", FirstPlayer);

                var Game = new Game(start);
                Game.Deal();               

                Console.WriteLine($"\nAI has total: {Game.PlayerAI.Hand.TotalValue()}");
                foreach (Card card in Game.PlayerAI.Hand.Cards)
                    Console.WriteLine("\t" + card.rank + " " + card.suit);

                Console.WriteLine($"\nYou have total: {Game.PlayerHuman.Hand.TotalValue()}");
                foreach (Card card in Game.PlayerHuman.Hand.Cards)
                    Console.WriteLine("\t" + card.rank + " " + card.suit);

                while (Game.AllowedAction == GameAction.Play)
                {
                    Console.Write("\nWant additional card (y/n)? -- \t");
                    if (Console.ReadLine() == "y")
                        Game.AskCard();
                    else
                    {
                        Game.SkipCard();
                        Game.CheckValue();
                    }

                    Console.WriteLine($"\nAI has total: {Game.PlayerAI.Hand.TotalValue()}");
                    foreach (Card card in Game.PlayerAI.Hand.Cards)
                        Console.WriteLine("\t" + card.rank + " " + card.suit);

                    Console.WriteLine($"\nYou have total: {Game.PlayerHuman.Hand.TotalValue()}");
                    foreach (Card card in Game.PlayerHuman.Hand.Cards)
                        Console.WriteLine("\t" + card.rank + " " + card.suit);
                }

                Game.CheckValue();
                if (Game.LastState == GameState.AIWon)
                {
                    Console.WriteLine("YOU LOSE!!!");
                    AIWins++;
                }
                else if (Game.LastState == GameState.HumanWon)
                {
                    Console.WriteLine("YOU WON!!!");
                    HumanWins++;
                }                    
                else if (Game.LastState == GameState.Draw)
                {
                    Console.WriteLine("DRAW!!!");
                    Draws++;
                }                    

                Console.Write("\nWant play again (y/n)? -- \t");
                userInput = Console.ReadLine();
            }

            Console.WriteLine("\nGame statistic:");
            Console.WriteLine($"AI won {AIWins} times");
            Console.WriteLine($"You won {HumanWins} times");
            Console.WriteLine($"Draw was {Draws} times");

            Console.Write("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
