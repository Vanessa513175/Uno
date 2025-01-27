using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PlayUnoGUI
{
    public class ViewModelCard : ViewModelBase
    {
        #region Fields and Properties

        private Color _color;
        /// <summary>
        /// The color of the card
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                RaisePropertyChanged();
            }
        }

        private string _value;
        /// <summary>
        /// The value of the card
        /// </summary>
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ViewModelCard()
        {
            _color = Colors.White;
            _value = string.Empty; 
        }

        #endregion

        #region Methods
        #endregion
    }
}
