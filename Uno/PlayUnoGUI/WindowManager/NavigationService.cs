using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PlayUnoGUI.View;

namespace PlayUnoGUI.WindowManager
{
    public class NavigationService : INavigationService
    {
        private Window? _currentWindow;

        public NavigationService(Window currentWindow)
        {
            _currentWindow = currentWindow;
        }

        public NavigationService()
        {
            _currentWindow = null;
        }

        public void NavigateTo(string viewName)
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
                    nextWindow = new ViewPlayerWindow(this);
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
