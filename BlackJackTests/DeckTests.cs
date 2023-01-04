using Blackjack;

namespace BlackjackTests
{
    [TestClass]
    public class DeckTests
    {
        //Ensure deck constructor builds deck with 52 cards
        [TestMethod]
        public void DeckContains52Cards()
        {
            // Arrange
            int expectedCardTotal = 52;

            // Act
            Deck deck = new Deck();

            // Assert
            int actual = deck.GetDeck().Count;
            Assert.AreEqual(expectedCardTotal, actual);
        }
    }
}