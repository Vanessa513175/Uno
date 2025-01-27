using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayUnoGUI.View;
using System.Windows;

namespace PlayUnoGUI.Manager
{
    public class WindowManager
    {
        private static WindowManager? _instance;

        private readonly Dictionary<string, Window> _windows;

        public static WindowManager Instance => _instance ??= new WindowManager();

        private WindowManager()
        {
            _windows = new Dictionary<string, Window>();
        }

        public void OpenWindow(Window window)
        {
            if (!_windows.ContainsKey(window.Name))
            {
                _windows[window.Name] = window;
                window.Show();
            }
        }

        public void CloseWindow(string windowName)
        {
            if (_windows.ContainsKey(windowName))
            {
                _windows[windowName].Close();
                _windows.Remove(windowName);
            }
        }

        public void CloseAllWindows()
        {
            foreach (var window in _windows.Values)
            {
                window.Close();
            }
            _windows.Clear();
        }
    }
}