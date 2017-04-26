using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public enum SuitName { Clubs, Diamonds, Hearts, Spades }

    public class Card
    {
        #region Members

        public SuitName Suit { get; set; }
        public string Face { get; set; }

        #endregion

        #region Constructor

        public Card(SuitName suitName, int cardValue)
        {
            this.Suit = suitName;
            this.Face = getFaceAsString(cardValue);
        }

        #endregion

        #region Private Method

        private string getFaceAsString(int f)
        {
            string sReturnValue = string.Empty;

            switch (f)
            {
                case 1:
                    sReturnValue = "Ace";
                    break;
                case 11:
                    sReturnValue = "Jack";
                    break;
                case 12:
                    sReturnValue = "Queen";
                    break;
                case 13:
                    sReturnValue = "King";
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    sReturnValue = f.ToString();
                    break;
                default:
                    sReturnValue = string.Empty;
                    break;
            }

            return sReturnValue;
        }

        #endregion
    }

    public class Deck : IDisposable
    {
        #region Memebers

        private List<Card> WholeDeck = new List<Card>();
        private bool isDeckShuffled = false;
        private const int SuitCards = 13;

        #endregion

        #region Class Maintenance Methods

        public Deck()
        {
            Init();
        }

        public void Dispose()
        {
            WholeDeck = null;
        }

        public void Init()
        {
            Array allSuits = Enum.GetValues(typeof(SuitName));

            if (WholeDeck.Count > 0)
            {
                WholeDeck.Clear();
            }

            foreach (SuitName suitName in allSuits)
            {
                for (int i = 1; i <= SuitCards; i++)
                {
                    WholeDeck.Add(new Card(suitName, i));
                }
            }
        }

        #endregion

        #region Public Methods

        public void Shuffle()
        {
            Card c;
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            int iRandomIndex1 = 0;
            int iRandomIndex2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                iRandomIndex1 = rnd1.Next(0, WholeDeck.Count);
                iRandomIndex2 = rnd1.Next(1, WholeDeck.Count);
                if (iRandomIndex1 != iRandomIndex2)
                {
                    c = WholeDeck[iRandomIndex1];
                    WholeDeck[iRandomIndex1] = WholeDeck[iRandomIndex2];
                    WholeDeck[iRandomIndex2] = c;
                }
            }

            isDeckShuffled = true;
        }

        public string DealOneCardFromFront()
        {
            string sReturnCard = string.Empty;
            sReturnCard = DealOneCard(0);
            return sReturnCard;
        }

        public string DealOneCardFromEnd()
        {
            string sReturnCard = string.Empty;
            sReturnCard = DealOneCard(WholeDeck.Count - 1);
            return sReturnCard;
        }

        public string DealOneCardFromMiddle()
        {
            string sReturnCard = string.Empty;
            Random rnd = new Random();
            int iRandomIndex = rnd.Next(0, WholeDeck.Count);

            sReturnCard = DealOneCard(iRandomIndex);
            return sReturnCard;
        }

        public string DealOneCard(int iDealingCard)
        {
            string sReturnCard = string.Empty;
            //int dealingCard;

            if (isDeckShuffled)
            {
                if (WholeDeck.Count > 0)
                {
                    //dealingCard = WholeDeck.Count - 1;
                    Card c;

                    c = WholeDeck[iDealingCard];
                    WholeDeck.RemoveAt(iDealingCard);

                    sReturnCard = CardName(c);
                }
                else
                {
                    sReturnCard = "All cards have been dealt.";
                }
            }
            else
            {
                sReturnCard = "Deck is not shuffled yet.";
            }

            return sReturnCard;
        }

        public string ShowDeck()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Card c in WholeDeck)
            {
                sb.AppendFormat("{0,17}{1}", CardName(c), Environment.NewLine);
            }
            sb.AppendFormat("Remaining cards in deck: {0}", WholeDeck.Count());

            return sb.ToString();
        }

        public int CardsInDeckCount()
        {
            int iReturnCount = 0;
            iReturnCount = WholeDeck.Count();
            return iReturnCount;
        }

        #endregion

        #region Private Method

        private string CardName(Card c)
        {
            string returnCard = string.Empty;
            returnCard = c.Face + " of " + c.Suit.ToString();
            return returnCard;
        }

        #endregion
    }
}
