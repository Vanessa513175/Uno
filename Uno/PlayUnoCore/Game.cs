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
        private List<Player> _players;
        private Deck _deck;
        private Card _currentCard;
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

        private void PlayTurn()
        {
            var currentPlayer = _players[_currentPlayerIndex];

            // Afficher les cartes du joueur

            // Demander une carte au joueur

            // Valider si la carte peut être jouée

            // Pioche ?

            // Passer au joueur suivant
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }

        private string GetCardsOfCurrentPlayer()
        {
            var currentPlayer = _players[_currentPlayerIndex];
            var cardsInHand = currentPlayer.CardsInHand;

            var cardList = cardsInHand
                .Select((card, index) => $"{index}: {card}")
                .ToList();

            return string.Join(", ", cardList);
        }

        private Card GetChoiceOfCurrentPlayer(int indexOfCards)
        {
            var currentPlayer = _players[_currentPlayerIndex];

            if (indexOfCards >= 0 && indexOfCards < currentPlayer.CardsInHand.Count)
            {
                return currentPlayer.CardsInHand[indexOfCards];
            }
            else
            {
                throw new Exception("Choix de carte non valide pour " + currentPlayer.Name);
            }
        }
        #endregion

        #region Public Methods
        public bool IsGameOver()
        {
            return _players.Any(player => player.CardsInHand.Count == 0);
        }

        public void StartGame() 
        {
            DealInitialCards();
        }
        #endregion
        #endregion
    }
}
