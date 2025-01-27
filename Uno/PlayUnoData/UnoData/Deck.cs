using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using static PlayUnoData.UnoData.Card;

namespace PlayUnoData.UnoData
{
    public class Deck
    {
        #region Enum
        #endregion

        #region Constants
        private const int NUMBER_OF_NUMBER_CARDS = 10;
        private const int WILD_CART_COUNT = 4; // Wild, WildDrawFour

        public const string LABEL_RED = "Red";
        public const string LABEL_GREEN = "Green";
        public const string LABEL_BLUE = "Blue";
        public const string LABEL_YELLOW = "Yellow";
        public const string LABEL_BLACK = "Black";
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private Stack<Card> _cards;
        private Card? _currentCard;
        private readonly Stack<Card> _oldCards;

        /// <summary>
        /// Get the current card of the deck
        /// </summary>
        public Card? CurrentCard { 
            get { return _currentCard; } 
            set
            {
                _currentCard = value;
            }
        }

        /// <summary>
        /// Get the number of cards remaining
        /// </summary>
        public int RemainingCards => _cards.Count;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Deck()
        {
            _cards = new Stack<Card>();
            _oldCards = new Stack<Card>();
            InitializeDeck();
            Shuffle();
            _currentCard = DrawCard();
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        /// <summary>
        /// Initialize Deck
        /// </summary>
        private void InitializeDeck()
        {
            List<string> colors = [LABEL_RED, LABEL_BLUE, LABEL_GREEN, LABEL_YELLOW];
            // Add number cards (0-9)
            foreach (string color in colors)
            {
                // Add one 0 card
                _cards.Push(new Card(CardType.Number, color, 0));

                // Add two copies of cards 1-9
                for (int value = 1; value < NUMBER_OF_NUMBER_CARDS; value++)
                {
                    _cards.Push(new Card(CardType.Number, color, value));
                    _cards.Push(new Card(CardType.Number, color, value));
                }

                // Add two Reverse, Skip, and DrawTwo cards per color
                _cards.Push(new Card(CardType.Reverse, color));
                _cards.Push(new Card(CardType.Reverse, color));
                _cards.Push(new Card(CardType.Skip, color));
                _cards.Push(new Card(CardType.Skip, color));
                _cards.Push(new Card(CardType.DrawTwo, color));
                _cards.Push(new Card(CardType.DrawTwo, color));
            }

            // Add Wild and WildDrawFour cards
            for (int i = 0; i < WILD_CART_COUNT; i++)
            {
                _cards.Push(new Card(CardType.Wild, LABEL_BLACK));
                _cards.Push(new Card(CardType.WildDrawFour, LABEL_BLACK));
            }
        }

        /// <summary>
        /// Suffle cards
        /// </summary>
        private void Shuffle()
        {
            var cardsArray = _cards.ToArray();
            var random = new Random();
            for (int i = cardsArray.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (cardsArray[i], cardsArray[j]) = (cardsArray[j], cardsArray[i]);
            }
            _cards = new Stack<Card>(cardsArray);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Draw a card
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Card DrawCard()
        {
            if (_cards.Count == 0)
            {
                if (_oldCards.Count == 0) { 
                    Logger.Instance.Log(Logger.ELevelMessage.Error, "Problème de gestion de la pioche (vide)");
                }

                // Reshuffle old cards into the deck
                ResetDeck();
            }
            return _cards.Pop();
        }

        /// <summary>
        /// Play a card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool PlayCard(Card card)
        {
            if (card == null) { 
                Logger.Instance.Log(Logger.ELevelMessage.Error, "DECK : " + nameof(card) + " Carte ne peut pas être null");
                return false;
            }
            if (_currentCard == null)
            {
                Logger.Instance.Log(Logger.ELevelMessage.Error, "DECK : " +nameof(_currentCard) + " Carte ne peut pas être null");
                return false;
            }

            if (card.Color != _currentCard.Color && card.Type != _currentCard.Type && card.Color != LABEL_BLACK)
            {
                return false;
            }

            _oldCards.Push(_currentCard);
            _currentCard = card;
            return true;
        }

        /// <summary>
        /// Reset Deck
        /// </summary>
        /// <param name="cards"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ResetDeck()
        {
            _cards = _oldCards;
            _oldCards.Clear();
            Shuffle();
        }

        /// <summary>
        /// Restart Deck
        /// </summary>
        public void RestartDeck()
        {
            _cards.Clear();
            _oldCards.Clear();
            InitializeDeck();
            Shuffle();
            _currentCard = DrawCard();
        }
        #endregion
        #endregion
    }
}
