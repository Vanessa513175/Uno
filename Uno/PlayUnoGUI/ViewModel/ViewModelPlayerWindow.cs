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
using Core;

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
        private readonly NavigationService _navigationService;

        /// <summary>
        /// The local Game Model
        /// </summary>
        public GameModel GameModel 
        { 
            get; 
            private set; 
        }

        private readonly Guid _playerId;

        private Player _player;
        /// <summary>
        /// Get the player name (for title)
        /// </summary>
        public string PlayerName
        {
            get => _player?.Name ?? "Joueur inconnu";
            private set
            {
                if (_player != null)
                {
                    _player.Name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int DeckCardCount => GameModel.CurrentDeck?.RemainingCards ?? 0;
        public int PlayerCardCount => PlayerHandViewModel?.CardsInHand.Count ?? 0;
        public int PlayerCount => GameModel.Players?.Count ?? 0;


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

        private bool _isPlayerTurn;
        /// <summary>
        /// Check if is player turn
        /// </summary>
        public bool IsPlayerTurn
        {
            get => _isPlayerTurn;
            set
            {
                _isPlayerTurn = value;
                RaisePropertyChanged();
            }
        }

        public ViewModelCard _currentCardViewModel;
        /// <summary>
        /// Get the current card
        /// </summary>
        public ViewModelCard CurrentCardViewModel
        {
            get { return _currentCardViewModel; }
            set
            {
                _currentCardViewModel = value;
                RaisePropertyChanged();
            }
        }

        private ViewModelCardsInHand _playerHandViewModel;
        /// <summary>
        /// Get the Player Hand (View Model)
        /// </summary>
        public ViewModelCardsInHand PlayerHandViewModel
        {
            get { return _playerHandViewModel; }
            set
            {
                _playerHandViewModel = value;
                RaisePropertyChanged();
            }
        }

        private StringBuilder _logBuilder = new StringBuilder();
        private string _logText;
        /// <summary>
        /// Log Text Management
        /// </summary>
        public string LogText
        {
            get => _logText;
            set
            {
                _logText = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public ViewModelPlayerWindow(NavigationService navService, Guid playerId)
        {
            _navigationService = navService;
            _playerId = playerId;

            _currentCardViewModel = new ViewModelCard();
            _playerHandViewModel = new ViewModelCardsInHand();
            OtherPlayers = [];
            Logger.Instance.LogUpdated += OnLogUpdated;

            UpdateGameModel(_navigationService.ShareGameModel);
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        private void OnLogUpdated(string newLog)
        {
            _logBuilder.AppendLine(newLog);
            LogText = _logBuilder.ToString();
        }

        private void UpdateCardsInHand()
        {
            PlayerHandViewModel.CardsInHand.Clear();
            if (_player != null)
            {
                foreach (Card c in _player.CardsInHand)
                {
                    PlayerHandViewModel.AddCard(c);
                }
            }
        }
        #endregion

        #region Public Methods
        public void UpdateGameModel(GameModel gameModel)
        {
            GameModel = gameModel;

            _player = GameModel.Players.FirstOrDefault(p => p.PlayerId == _playerId);
            OtherPlayers = GameModel.Players.Where(p => p.PlayerId != _playerId).ToList();

            if (GameModel.CurrentDeck?.CurrentCard != null)
                CurrentCardViewModel.CardObject = GameModel.CurrentDeck.CurrentCard;

            IsPlayerTurn = (_player != null && GameModel.CurrentPlayer == _player);

            UpdateCardsInHand();
        }

        public void SaveGameModel()
        {

        }
        #endregion

        #endregion

    }
}
