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
                Console.WriteLine("Dealing cards...\n");
                //Time delay on printing, for user readability 
                Thread.Sleep(2000);
                //Create a new deck object
                Deck deck = new Deck();
                //Create player and dealer hand objects
                Hand playerHand = new Hand("Your");
                Hand dealerHand = new Hand("Dealer", true);
                //Draw two cards for both player and dealer
                dealerHand.hit(deck.DrawCard());
                playerHand.hit(deck.DrawCard());
                dealerHand.hit(deck.DrawCard());
                playerHand.hit(deck.DrawCard());
                //Print hands for both player and dealer
                dealerHand.PrintHandInfo();
                playerHand.PrintHandInfo();
   

                //If dealer 1st card has value of 10 or 11, check hole card for dealer blackjack
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
                              
                //Player's turn, continues until player busts or stands
                while (playerTurn)
                {
                    //Check if player has blackjack, if so player wins, break the loop and end the game
                    if(playerHand.GetHandValue() == 21)
                    {
                        Console.WriteLine("Blackjack! You win!");
                        playerTurn = false;
                        break;
                    }
                    Console.WriteLine("Hit (h) or Stand (s)?");
                    input = Console.ReadLine();
                    //Player hits and draws a card. Checks if over 21, if not game continues, if so player busts and game over
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
                    //Player stands, reveal dealer hole card and begin dealer's turn
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
                //------------------------
                //Dealers turn, ending until dealer busts or hand value is 17 or greater
                //House rules: Dealer always hits when below 17, and always stands whens 17 or above
                while (dealerTurn)
                {
                    if (dealerHand.GetHandValue() < 17)
                    {
                        //Dealer hits when under 17
                        Console.WriteLine("*Dealer Hits!*\n");
                        Thread.Sleep(1000);
                        dealerHand.hit(deck.DrawCard());
                        dealerHand.PrintHandInfo();
                        //If over 21, dealer busts and player wins
                        if (dealerHand.GetHandValue() > 21)
                        {
                            Console.WriteLine("Dealer Bust! You win!");
                            dealerTurn = false;
                        //If dealer has 21, dealer blackjack and player loses
                        } else if(dealerHand.GetHandValue() == 21)
                        {
                            Console.WriteLine("Dealer Blackjack! You lose...");
                            dealerTurn = false;
                        }
                    } else
                    {
                        //Dealer stands when 17 or above
                        Console.WriteLine("*Dealer Stands!*\n");
                        Thread.Sleep(2000);
                        //Compare hand values. 
                        //Player hand exceeds dealer hand, player wins
                        if (dealerHand.GetHandValue() < playerHand.GetHandValue())
                        {
                            Console.WriteLine("Your hand ({0}) beats the dealer ({1})! You win!", playerHand.GetHandValue(), dealerHand.GetHandValue());
                        //Dealer hand exceeds player hand, player loses
                        } else if(dealerHand.GetHandValue() > playerHand.GetHandValue())
                        {
                            Console.WriteLine("Your hand ({0}) is beaten by the dealer ({1})! Dealer wins...", playerHand.GetHandValue(), dealerHand.GetHandValue());
                        //Hand values are the same, tie
                        } else
                        {
                            Console.WriteLine("Standoff! Tie.");
                        }
                        dealerTurn = false;
                    }
                }

                //Check to continue playing
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
