using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayUnoCore
{
    public class Game
    {
        #region Enum
        #endregion

        #region Constants
        private const int NUMBER_OF_CARDS = 7;
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private readonly List<Player> _players;
        private readonly Deck _deck;
        private int _currentPlayerIndex;
        #endregion

        #region Constructor
        public Game(IEnumerable<string> playerNames)
        {
            if (playerNames == null || !playerNames.Any())
                throw new ArgumentException("Il faut au moins 2 joueurs pour commencer la partie");

            _players = playerNames.Select(name => new Player(name)).ToList();
            _deck = new Deck();
            _currentPlayerIndex = 0;
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        private void DealInitialCards()
        {
            foreach (var player in _players)
            {
                for (int i = 0; i < NUMBER_OF_CARDS; i++)
                {
                    player.AddCardToHand(_deck.DrawCard());
                }
            }
        }
        #endregion

        #region Public Methods
        public void NextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }

        public bool IsGameOver()
        {
            return _players.Any(player => player.CardsInHand.Count == 0);
        }

        public void StartGame() 
        {
            DealInitialCards();
            _currentPlayerIndex = 0;
        }

        public List<Card> GetCardsOfCurrentPlayer()
        {
            return _players[_currentPlayerIndex].CardsInHand;
        }

        public string GetCardsOfCurrentPlayerString()
        {
            var currentPlayer = _players[_currentPlayerIndex];
            var cardsInHand = currentPlayer.CardsInHand;

            var cardList = cardsInHand
                .Select((card, index) => $"{index}: {card}")
                .ToList();

            return string.Join(", ", cardList);
        }

        public bool PlayCardForCurrentPlayer(Card card)
        {
            try
            {
                _players[_currentPlayerIndex].RemoveCardFromHand(card);
            }
            catch
            {
                return false;
            }
            try
            {
                _deck.PlayCard(card);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void DeawCardForCurrentPlayer()
        {
            _players[_currentPlayerIndex].AddCardToHand(_deck.DrawCard());
        }

        public string GetCurrentPlayerName()
        {
            return _players[_currentPlayerIndex].Name;
        }

        public string GetCurrentCardName() {
            return _deck.CurrentCard.ToString();
        }
        #endregion
        #endregion
    }
}
