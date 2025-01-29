using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PlayUnoData.PlayersData;
using PlayUnoGUI.View;

namespace PlayUnoGUI.WindowManager
{
    public class NavigationService
    {
        private Window? _currentWindow;

        public GameModel ShareGameModel;

        public NavigationService(Window currentWindow)
        {
            _currentWindow = currentWindow;
            ShareGameModel = new GameModel();
        }

        public NavigationService()
        {
            _currentWindow = null;
            ShareGameModel = new GameModel();
        }

        public void NavigateTo(string viewName, Guid playerId = default)
        {
            Window? nextWindow = null;

            switch (viewName)
            {
                case "ChoosePlayers":
                    nextWindow = new ViewChoosePlayers(this);
                    break;
                //case "StatsWindow":
                //    nextWindow = new StatsWindow();
                //    break;
                case "PlayerWindow":
                    nextWindow = new ViewPlayerWindow(this, playerId);
                    break;
                default:
                    throw new ArgumentException("Vue non prise en charge");
            }

            if (nextWindow != null)
            {
                nextWindow.Show();
                _currentWindow?.Close();
                _currentWindow = nextWindow;
                nextWindow = null;
            }
        }
    }
}
