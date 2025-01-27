using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Core;
using PlayUnoData.PlayersData;
using PlayUnoGUI.Manager;
using PlayUnoGUI.View;
using static System.Net.Mime.MediaTypeNames;

namespace PlayUnoGUI.ViewModel
{
    public class ViewModelChoosePlayers : ViewModelBase
    {
        #region Enum
        #endregion

        #region Constants
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private ObservableCollection<Player> _knowPlayers;
        public ObservableCollection<Player> KnownPlayers 
        { 
            get {  return _knowPlayers; } 
            set
            {
                _knowPlayers = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Player> _playersToAdd;
        public ObservableCollection<Player> PlayersToAdd 
        { 
            get { return _playersToAdd; }
            set
            {
                _playersToAdd = value;
                RaisePropertyChanged();
            }
        }

        private string _newPlayerName;
        public string NewPlayerName { 
            get { return _newPlayerName; }
            set
            {
                _newPlayerName = value;
                RaisePropertyChanged();
            } 
        }

        public bool CanNext
        {
            get { return PlayersToAdd.Count > 2; }
        }

        public ICommand AddPlayerCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        #endregion

        #region Constructor
        public ViewModelChoosePlayers()
        {
            _newPlayerName = String.Empty;
            _knowPlayers = new ObservableCollection<Player>();
            _playersToAdd = new ObservableCollection<Player>();

            AddPlayerCommand = new RelayCommand(AddPlayer);
            NextCommand = new RelayCommand(Next, CanNext);
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        private void AddPlayer()
        {
            if (!string.IsNullOrWhiteSpace(NewPlayerName))
            {
                var newPlayer = new Player ( NewPlayerName );
                PlayersToAdd.Add(newPlayer);
                NewPlayerName = string.Empty;
                RaisePropertyChanged("CanNext");
            }
        }

        private void Next()
        {
            Logger.Instance.Log(Logger.ELevelMessage.Info, "Création d'une partie avec " + PlayersToAdd.Count + " joueurs");
            WindowManager.Instance.CloseWindow("ChoosePlayers");
            WindowManager.Instance.OpenWindow(new ViewPlayerWindow());
        }
        #endregion

        #region Public Methods
        #endregion

        #endregion

    }
}
