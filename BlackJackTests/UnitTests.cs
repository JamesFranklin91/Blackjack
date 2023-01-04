using Blackjack;

namespace BlackjackTests
{
    [TestClass]
    public class UnitTests
    {
        //Ensure deck constructor builds deck with 52 cards
        [TestMethod]
        public void DeckConstructor_ShouldHaveFiftyTwoCards()
        {
            // Arrange
            int expectedDeckTotal = 52;

            // Act
            Deck deck = new Deck();

            // Assert
            int actual = deck.GetDeck().Count;
            Assert.AreEqual(expectedDeckTotal, actual);
        }

        //Ensure deck has correct number of cards when drawing specific number of cards
        [TestMethod]
        public void DeckDrawCard_WhenDrawFiveCards_ShouldHaveFortySevenCardsRemaining()
        {
            // Arrange
            int expectedDeckTotal = 47;

            // Act
            Deck deck = new Deck();
            deck.DrawCard();
            deck.DrawCard();
            deck.DrawCard();
            deck.DrawCard();
            deck.DrawCard();

            // Assert
            int actual = deck.GetDeck().Count;
            Assert.AreEqual(expectedDeckTotal, actual);
        }

        //Ensure opening hand contains two cards
        [TestMethod]
        public void HandHit_WhenDealtOpeningHand_ShouldHaveTwoCards()
        {
            // Arrange
            int expectedHandTotal = 2;

            // Act
            Deck deck = new Deck();
            Hand hand = new Hand("Player");
            hand.hit(deck.DrawCard());
            hand.hit(deck.DrawCard());

            // Assert
            int actual = hand.GetHand().Count;
            Assert.AreEqual(expectedHandTotal, actual);
        }

        //Ensure hand total is 21 if hand is King and Ace
        [TestMethod]
        public void Hand_WhenKingAce_ShouldScoreTwentyOne()
        {
            // Arrange
            int expectedScore = 21;

            // Act
            Hand hand = new Hand("Player");
            hand.hit(new Card(Card.suits.Hearts, Card.numbers.King));
            hand.hit(new Card(Card.suits.Hearts, Card.numbers.Ace));

            // Assert
            int actual = hand.GetHandValue();
            Assert.AreEqual(expectedScore, actual);
        }

        //Ensure hand total is 21 if hand is King, Queen, and Ace
        [TestMethod]
        public void Hand_WhenKingQueenAce_ShouldScoreTwentyOne()
        {
            // Arrange
            int expectedScore = 21;

            // Act
            Hand hand = new Hand("Player");
            hand.hit(new Card(Card.suits.Hearts, Card.numbers.King));
            hand.hit(new Card(Card.suits.Hearts, Card.numbers.Queen));
            hand.hit(new Card(Card.suits.Hearts, Card.numbers.Ace));

            // Assert
            int actual = hand.GetHandValue();
            Assert.AreEqual(expectedScore, actual);
        }

        //Ensure hand total is 21 if hand is Nine, Ace, and Ace

        [TestMethod]
        public void Hand_WhenNineAceAce_ShouldScoreTwentyOne()
        {
            // Arrange
            int expectedScore = 21;

            // Act
            Hand hand = new Hand("Player");
            hand.hit(new Card(Card.suits.Hearts, Card.numbers.Nine));
            hand.hit(new Card(Card.suits.Hearts, Card.numbers.Ace));
            hand.hit(new Card(Card.suits.Diamonds, Card.numbers.Ace));

            // Assert
            int actual = hand.GetHandValue();
            Assert.AreEqual(expectedScore, actual);
        }
    }
}