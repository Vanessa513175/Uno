using System.Drawing;
using static PlayUnoCore.ENUMS;

namespace PlayUnoCore
{
    /// <summary>
    /// Card of uno
    /// </summary>
    public class Card
    {
        #region Enum
        #endregion

        #region Constants
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private CardType _type;
        public CardType Type { get { return _type; } }

        private CardColor _color;
        public CardColor Color { get { return _color; } }

        private int _value;
        public int Value { get { return _value; } } 
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public Card(CardType type, CardColor color, int value = -1)
        {
            _type = type;
            _color = color;
            _value = value;

            // Validations: Only Number cards should have a value
            if (type == CardType.Number && (value < 0 || value > 9))
                throw new ArgumentException("The value of a Number card must be between 0 and 9");
            if (type != CardType.Number && value != -1)
                throw new ArgumentException("Only Number cards can have a value");
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
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
