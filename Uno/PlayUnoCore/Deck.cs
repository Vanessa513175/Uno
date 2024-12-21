using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlayUnoCore.ENUMS;

namespace PlayUnoCore
{
    /// <summary>
    /// Deck of cards
    /// </summary>
    public class Deck
    {
        #region Enum
        #endregion

        #region Constants
        private const int NumberOfColors = 4;
        private const int NumberOfNumberCards = 10;
        private const int SpecialCardsPerColor = 2; // Reverse, Skip, DrawTwo
        private const int WildCardsCount = 4; // Wild, WildDrawFour
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private Stack<Card> _cards;
        private Card _currentCard;
        private Stack<Card> _oldCards;

        public Card CurrentCard { get { return _currentCard; } }
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
            // Add number cards (0-9)
            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                if (color == CardColor.Black) continue; // Skip black color for number cards

                // Add one 0 card
                _cards.Push(new Card(CardType.Number, color, 0));

                // Add two copies of cards 1-9
                for (int value = 1; value < NumberOfNumberCards; value++)
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
            for (int i = 0; i < WildCardsCount; i++)
            {
                _cards.Push(new Card(CardType.Wild, CardColor.Black));
                _cards.Push(new Card(CardType.WildDrawFour, CardColor.Black));
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
                if (_oldCards.Count == 0)
                    throw new InvalidOperationException("Problème de gestion de la pioche (vide)");

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
            if (card == null)
                throw new ArgumentNullException(nameof(card), "Carte ne peut pas être null");

            if (card.Color != _currentCard.Color && card.Type != _currentCard.Type && card.Color != CardColor.Black)
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
