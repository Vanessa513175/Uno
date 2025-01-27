using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PlayUnoData.PlayersData;
using PlayUnoData.UnoData;

namespace PlayUnoGUI.ViewModel
{
    public class ViewModelPlayerWindow : ViewModelBase
    {
        #region Enum
        #endregion

        #region Constants
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        public Player _player;
        public Deck _deck;

        /// <summary>
        /// Get the player name (for title)
        /// </summary>
        public string PlayerName
        {
            get { return _player.Name; }
            private set
            {
                _player.Name = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Get Deck Card Count
        /// </summary>
        public int DeckCardCount
        {
            get { return _deck.RemainingCards; }
        }

        public int PlayerCardCount
        {
            get { return PlayerHand.CardsInHand.Count; }
        }

        public ViewModelCard _currentCard;
        /// <summary>
        /// Get the current card
        /// </summary>
        public ViewModelCard CurrentCard 
        { 
            get { return _currentCard; }
            set
            {
                _currentCard = value;
                RaisePropertyChanged();
            }
        }

        private ViewModelCardsInHand _playerHand;

        public ViewModelCardsInHand PlayerHand
        {
            get { return _playerHand; }
            set 
            { 
                _playerHand = value; 
                RaisePropertyChanged(); 
            }
        }

        public int PlayerCount 
        {
            get { return OtherPlayers.Count + 1; } 
        }

        public List<Player> OtherPlayers;

        public bool IsPlayerTurn;
        #endregion

        #region Constructor
        public ViewModelPlayerWindow()
        {
            OtherPlayers = [];

            _player = new Player("Pepita");
            _deck = new Deck();
            CurrentCard = new ViewModelCard();

            PlayerHand = new ViewModelCardsInHand();
            for (int i = 0; i < 7; i++)
            {
                PlayerHand.AddCard(_deck.DrawCard());
            }

            if (_deck.CurrentCard != null)
                CurrentCard.CardObject = _deck.CurrentCard;
            
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        #endregion

        #region Public Methods
        #endregion

        #endregion

    }
}
