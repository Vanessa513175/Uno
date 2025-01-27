using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace PlayUnoData.UnoData
{
    public class Card
    {
        #region Enum
        public enum CardType
        {
            Number,
            Reverse,
            DrawTwo,
            Skip,
            Wild,
            WildDrawFour
        }
        #endregion

        #region Constants
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private CardType _type;
        /// <summary>
        /// Get the type of the card
        /// </summary>
        public CardType Type { 
            get { return _type; } 
            set {  _type = value; }
        }

        private string _color;
        /// <summary>
        /// Get the color of the card
        /// </summary>
        public string Color { 
            get { return _color; } 
            set { _color = value; }
        }

        private int _value;
        /// <summary>
        /// Get the value of the card
        /// </summary>
        public int Value { 
            get { return _value; } 
            set { _value = value; }
        }

        /// <summary>
        /// Get the stirng value of the card
        /// </summary>
        public string StringValue { get { return CreateStringValue(); } }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public Card(CardType type, string color, int value = -1)
        {
            _type = type;
            _color = color;
            _value = value;

            if (type == CardType.Number && (value < 0 || value > 9))
                Logger.Instance.Log(Logger.ELevelMessage.Error, "CARD : The value of a Number card must be between 0 and 9");
            if (type != CardType.Number && value != -1)
                Logger.Instance.Log(Logger.ELevelMessage.Error, "CARD : Only Number cards can have a value");
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        /// <summary>
        /// Create the string value (for display)
        /// </summary>
        /// <returns></returns>
        private string CreateStringValue()
        {
            if (_value != -1)
            {
                return _value.ToString();
            }
            else
            {
                return _type.ToString();
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _type == CardType.Number
                ? $"{_color} {_value}"
                : $"{_color} {_type}";
        }
        #endregion

        #endregion
    }
}
