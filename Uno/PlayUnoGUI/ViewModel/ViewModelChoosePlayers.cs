using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Core;
using PlayUnoGUI.WindowManager;
using PlayUnoData.PlayersData;
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
        private readonly INavigationService _navigationService;

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
        public ViewModelChoosePlayers(INavigationService navService)
        {
            _navigationService = navService;

            _newPlayerName = String.Empty;
            _knowPlayers = [];
            _playersToAdd = [];

            AddPlayerCommand = new RelayCommand(AddPlayer);
            NextCommand = new RelayCommand(Next);
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
                RaisePropertyChanged(nameof(CanNext));
            }
        }

        private void Next()
        {
            if (CanNext)
            {
                Logger.Instance.Log(Logger.ELevelMessage.Info, "Création d'une partie avec " + PlayersToAdd.Count + " joueurs");
                _navigationService.NavigateTo("PlayerWindow");
            }
            else
            {
                Logger.Instance.Log(Logger.ELevelMessage.Warning, "Il faut au moins 2 joueurs pour créer une partie");
            }
        }
        #endregion

        #region Public Methods
        #endregion

        #endregion

    }
}
