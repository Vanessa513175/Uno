using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace PlayUnoGUI.ViewModel
{
    class ViewModelCardsInHand : ViewModelBase
    {
        #region Enum
        #endregion

        #region Constants
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private ObservableCollection<ViewModelCard> _cardsInHand;
        /// <summary>
        /// Cards in hand
        /// </summary>
        public ObservableCollection<ViewModelCard> CardsInHand
        {
            get { return _cardsInHand; }
            set
            {
                _cardsInHand = value;
                RaisePropertyChanged();
            }
        }

        private ViewModelCard? _selectedCard;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ViewModelCardsInHand()
        {
            _cardsInHand = [];
        }

        #endregion

        #region Methods

        #region Private and Protected Methods
        #endregion

        #region Public Methods
        /// <summary>
        /// Add a card
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(ViewModelCard card)
        {
            CardsInHand.Add(card);
        }

        /// <summary>
        /// Remove selected card
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveCard()
        {
            if(_selectedCard == null)
            {
                throw new InvalidOperationException("Aucune carte sélectionné");
            }
            CardsInHand.Remove(_selectedCard);
            _selectedCard = null;
        }
        #endregion

        #endregion

    }
}
