using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PlayUnoData.UnoData;

namespace PlayUnoGUI.ViewModel
{
    public class ViewModelCard : ViewModelBase
    {
        #region Constants
        private const int FONT_SIZE_FOR_NUMBER = 38;
        private const int FONT_SIZE_FOR_TEXT = 20;
        #endregion

        #region Fields and Properties
        private Card _cardObject;
        public Card CardObject
        {
            get { return _cardObject; }
            set
            {
                _cardObject = value;
                Color = _cardObject.Color;
                Value = _cardObject.StringValue;
            }
        }

        /// <summary>
        /// The color of the card
        /// </summary>
        public string Color
        {
            get { return _cardObject.Color; }
            set
            {
                _cardObject.Color = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The value of the card
        /// </summary>
        public string Value
        {
            get { return _cardObject.StringValue; }
            set
            {
                SetValueCard(value);
                RaisePropertyChanged();
            }
        }

        private int _fontSize;
        /// <summary>
        /// Font size for the text in card
        /// </summary>
        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
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
            _cardObject = new Card(Card.CardType.Number, "Gray", 0);
            _fontSize = FONT_SIZE_FOR_NUMBER;
        }

        #endregion

        #region Methods
        private void SetValueCard(string value)
        {
            if (int.TryParse(value, out int numericValue))
            {
                _cardObject.Value = numericValue;
                _cardObject.Type = Card.CardType.Number;
                FontSize = FONT_SIZE_FOR_NUMBER;
            }
            else
            {
                if (Enum.TryParse<Card.CardType>(value, true, out Card.CardType cardAction))
                {
                    _cardObject.Type = cardAction;
                    _cardObject.Value = -1;
                    FontSize = FONT_SIZE_FOR_TEXT;
                }
                else
                {
                    Logger.Instance.Log(Logger.ELevelMessage.Error, "ViewModelCard : Impossible de convertir la valeur (string) en valeur");
                }
            }
        }
        #endregion
    }
}
