using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PlayUnoData.UnoData;

namespace PlayUnoGUI
{
    public class ViewModelCard : ViewModelBase
    {
        #region Fields and Properties
        private readonly Card _cardObject;

        /// <summary>
        /// The color of the card
        /// </summary>
        public Color Color
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

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ViewModelCard()
        {
            _cardObject = new Card(Card.CardType.Number, Color.White, 0);
        }

        #endregion

        #region Methods
        private void SetValueCard(string value)
        {
            if (int.TryParse(value, out int numericValue))
            {
                _cardObject.Value = numericValue;
                _cardObject.Type = Card.CardType.Number;
            }
            else
            {
                if (Enum.TryParse<Card.CardType>(value, true, out Card.CardType cardAction))
                {
                    _cardObject.Type = cardAction;
                    _cardObject.Value = -1;
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
