using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayUnoData.UnoData;

namespace PlayUnoData.PlayersData
{
    public class GameModel : INotifyPropertyChanged
    {
        #region Enum
        #endregion

        #region Constants
        #endregion

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void SetField<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Field et Properties
        private List<Player> _players;
        public List<Player> Players
        {
            get { return _players; }
            set { SetField(ref _players, value, nameof(Players)); }
        }

        private Player _currentPlayer;
        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set { SetField(ref _currentPlayer, value, nameof(CurrentPlayer)); }
        }

        private Deck _currentDeck;
        public Deck CurrentDeck
        {
            get { return _currentDeck; }
            set { SetField(ref _currentDeck, value, nameof(CurrentDeck)); }
        }
        #endregion

        #region Constructor
        public GameModel(List<Player> players, Deck deck, Player player)
        {
            _players = players;
            _currentPlayer = player;
            _currentDeck = deck;
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        #endregion

        #region Public Methods
        public void ReinisializeDeck()
        {
            _currentDeck = new Deck();
        }
        #endregion

        #endregion

    }
}
