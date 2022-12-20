using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool session = true;
            bool playerTurn = true;
            bool dealerTurn = false;
            Console.WriteLine("Welcome to Blackjack!");

            //Continues until player decides to stop playing
            while (session)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("=================================================");
                Console.WriteLine("Dealing cards...");
                Thread.Sleep(2000);
                Console.WriteLine(" ");
                Deck deck = new Deck();
                Hand playerHand = new Hand("Your");
                Hand dealerHand = new Hand("Dealer", true);
                dealerHand.hit(deck.DrawCard());
                playerHand.hit(deck.DrawCard());
                dealerHand.hit(deck.DrawCard());
                playerHand.hit(deck.DrawCard());
                dealerHand.PrintHandInfo();
                playerHand.PrintHandInfo();
   

                //If dealer 1st card has value of 10 or 11, check for dealer blackjack
                if (dealerHand.GetHand()[0].GetValue() >= 10)
                {
                    Console.WriteLine("Dealer is checking for Blackjack...");
                    Thread.Sleep(2000);
                    if (dealerHand.GetHandValue() == 21)
                    {
                        //Reveal hole card
                        dealerHand.ToggleHidden();
                        dealerHand.PrintHandInfo();
                        if (playerHand.GetHandValue() == 21)
                        {
                            Console.WriteLine("Standoff! Tie.");
                        } else
                        {
                            Console.WriteLine("Dealer Blackjack! You lose...");
                        }
                        playerTurn = false;
                    }
                    else
                    {
                        Console.WriteLine("No dealer blackjack! Game continues.");
                    }
                    Console.WriteLine("");
                }
                              
                //Players turn, continues until player busts or stands
                while (playerTurn)
                {
                    if(playerHand.GetHandValue() == 21)
                    {
                        Console.WriteLine("Blackjack! You win!");
                        playerTurn = false;
                        break;
                    }
                    Console.WriteLine("Hit (h) or Stand (s)?");
                    input = Console.ReadLine();
                    if (input == "h")
                    {
                        playerHand.hit(deck.DrawCard());
                        playerHand.PrintHandInfo();
                        if (playerHand.GetHandValue() > 21)
                        {
                            Console.WriteLine("Bust! Game over.");
                            playerTurn = false;
                        }
                    }
                    else if (input == "s")
                    {
                        playerTurn = false;
                        dealerTurn = true;
                        dealerHand.ToggleHidden();
                        Console.WriteLine("---------");
                        Console.WriteLine("Dealer's turn!");
                        Console.WriteLine("---------");
                        Thread.Sleep(1000);
                        dealerHand.PrintHandInfo();
                        Thread.Sleep(1000);
                    } else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                //Dealers turn, ending until dealer busts or hand value is 17 or greater
                while (dealerTurn)
                {
                    if (dealerHand.GetHandValue() < 17)
                    {
                        Console.WriteLine("*Dealer Hits!*\n");
                        Thread.Sleep(1000);
                        dealerHand.hit(deck.DrawCard());
                        dealerHand.PrintHandInfo();
                        if (dealerHand.GetHandValue() > 21)
                        {
                            Console.WriteLine("Dealer Bust! You win!");
                            dealerTurn = false;
                        } else if(dealerHand.GetHandValue() == 21)
                        {
                            Console.WriteLine("Dealer Blackjack! You lose...");
                            dealerTurn = false;
                        }
                    } else
                    {
                        Console.WriteLine("*Dealer Stands!*\n");
                        Thread.Sleep(2000);
                        if (dealerHand.GetHandValue() < playerHand.GetHandValue())
                        {
                            Console.WriteLine("Your hand ({0}) beats the dealer ({1})! You win!", playerHand.GetHandValue(), dealerHand.GetHandValue());
                        } else if(dealerHand.GetHandValue() > playerHand.GetHandValue())
                        {
                            Console.WriteLine("Your hand ({0}) is beaten by the dealer ({1})! Dealer wins...", playerHand.GetHandValue(), dealerHand.GetHandValue());
                        } else
                        {
                            Console.WriteLine("Standoff! Tie.");
                        }
                        dealerTurn = false;
                    }
                }

                Console.WriteLine("Type (y) to play again, or any other key to quit.");
                input = Console.ReadLine();

                if(input != "y")
                {
                    session = false;
                } else
                {
                    playerTurn = true;
                }
            }
        }
    }
}
