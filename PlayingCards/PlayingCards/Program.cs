using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Deck d = new Deck())
            {
                char selectedOption;

                do
                {
                    selectedOption = DisplayMenu();

                    if (selectedOption == 'C')
                    {
                        Console.WriteLine("\nShowing all cards in deck");
                        Console.WriteLine(d.ShowDeck());
                    }
                    else if (selectedOption == 'S')
                    {
                        Console.WriteLine("\nShuffling deck");
                        d.Shuffle();
                        Console.WriteLine(d.ShowDeck());
                    }
                    else if (selectedOption == 'R')
                    {
                        Console.WriteLine("\nReseting deck");
                        d.Init();
                        Console.WriteLine(d.ShowDeck());
                    }
                    else if (selectedOption == 'F')
                    {
                        Console.Write("\nDealing a card from front: ");
                        Console.WriteLine(d.DealOneCardFromFront());
                        Console.Write("Remaining cards in deck: ");
                        Console.WriteLine(d.CardsInDeckCount().ToString());
                    }
                    else if (selectedOption == 'M')
                    {
                        Console.Write("\nDealing a card from middle: ");
                        Console.WriteLine(d.DealOneCardFromMiddle());
                        Console.Write("Remaining cards in deck: ");
                        Console.WriteLine(d.CardsInDeckCount().ToString());
                    }
                    else if (selectedOption == 'E')
                    {
                        Console.Write("\nDealing a card from end: ");
                        Console.WriteLine(d.DealOneCardFromEnd());
                        Console.Write("Remaining cards in deck: ");
                        Console.WriteLine(d.CardsInDeckCount().ToString());
                    }
                }
                while (selectedOption != 'Q');
            }
        }

        static char DisplayMenu()
        {
            ConsoleKeyInfo keyPressed;

            Console.WriteLine("\nWelcome to Cards Playing game.\n");
            Console.WriteLine("Press C to see all cards in deck.");
            Console.WriteLine("Press S to shuffle deck.");
            Console.WriteLine("Press R to reset deck.");
            Console.WriteLine("Press F to deal a card from front of deck.");
            Console.WriteLine("Press M to deal a card from middle of deck.");
            Console.WriteLine("Press E to deal a card from end of deck.");
            Console.WriteLine("Press Q to quit.\n");
            Console.Write("Please enter your selection: ");
            keyPressed = Console.ReadKey();

            return Char.ToUpper(keyPressed.KeyChar);
        }
    }

}