using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayUnoGUI.ViewModel
{
    public class ViewModelCentralBoard : ViewModelBase
    {
        #region Enum
        #endregion

        #region Constants
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private ViewModelCard? _currentCard;
        public ViewModelCard? CurrentCard
        {
            get { return _currentCard; }
            set
            {
                if (_currentCard != value)
                {
                    _currentCard = value;
                }
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public ViewModelCentralBoard()
        {

        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        #endregion

        #region Public Methods
        #endregion

        #endregion

    }
}
