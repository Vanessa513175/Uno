﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PlayUnoGUI.WindowManager;
using PlayUnoGUI.ViewModel;

namespace PlayUnoGUI.View
{
    /// <summary>
    /// Logique d'interaction pour ViewPlayerWindow.xaml
    /// </summary>
    public partial class ViewPlayerWindow : Window
    {
        public ViewPlayerWindow(NavigationService nav, Guid playerId)
        {
            InitializeComponent();
            DataContext = new ViewModelPlayerWindow(nav, playerId);
        }
    }
}
