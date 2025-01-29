using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PlayUnoGUI.WindowManager;
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
        private readonly INavigationService _navigationService;

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

        /// <summary>
        /// Get The Player Card Count
        /// </summary>
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
        /// <summary>
        /// Get the Player Hand (View Model)
        /// </summary>
        public ViewModelCardsInHand PlayerHand
        {
            get { return _playerHand; }
            set 
            { 
                _playerHand = value; 
                RaisePropertyChanged(); 
            }
        }

        /// <summary>
        /// Get the player count
        /// </summary>
        public int PlayerCount 
        {
            get { return OtherPlayers.Count + 1; } 
        }

        private List<Player> _othersPlayers;
        /// <summary>
        /// Get the list of other player
        /// </summary>
        public List<Player> OtherPlayers
        {
            get { return _othersPlayers; }
            set
            {
                _othersPlayers = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Check if it's the player turn
        /// </summary>
        public bool IsPlayerTurn;
        #endregion

        #region Constructor
        public ViewModelPlayerWindow(INavigationService navService)
        {
            _navigationService = navService;

            _currentCard = new ViewModelCard();
            _playerHand = new ViewModelCardsInHand();

            _player = new Player(String.Empty);
            _othersPlayers = [];

            _deck = new Deck();
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
