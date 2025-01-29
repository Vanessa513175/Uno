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
using System.Windows.Navigation;
using NavigationService = PlayUnoGUI.WindowManager.NavigationService;

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
        private readonly NavigationService _navigationService;

        private ObservableCollection<Player> _knowPlayers;
        /// <summary>
        /// List of know players
        /// </summary>
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
        /// <summary>
        /// List of players to add
        /// </summary>
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
        /// <summary>
        /// String contains the new player name
        /// </summary>
        public string NewPlayerName { 
            get { return _newPlayerName; }
            set
            {
                _newPlayerName = value;
                RaisePropertyChanged();
            } 
        }

        /// <summary>
        /// Check if can next command
        /// </summary>
        public bool CanNext
        {
            get { return PlayersToAdd.Count > 1; }
        }

        public ICommand AddPlayerCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navService"></param>
        public ViewModelChoosePlayers(NavigationService navService)
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
        /// <summary>
        /// Add a player
        /// </summary>
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

        /// <summary>
        /// Next command
        /// </summary>
        private void Next()
        {
            if (CanNext)
            {
                Logger.Instance.Log(Logger.ELevelMessage.Info, "Création d'une partie avec " + PlayersToAdd.Count + " joueurs");
                _navigationService.ShareGameModel.Players = PlayersToAdd.ToList();

                Logger.Instance.Log(Logger.ELevelMessage.Info, "Distibution des cartes");
                _navigationService.ShareGameModel.DrawCardToPlayers();

                _navigationService.NavigateTo("PlayerWindow", PlayersToAdd.FirstOrDefault().PlayerId);
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
