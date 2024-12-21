using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlayUnoCore
{
    /// <summary>
    /// Player of uno
    /// </summary>
    public class Player
    {
        #region Enum
        #endregion

        #region Constants
        #endregion

        #region Events
        #endregion

        #region Field et Properties
        private string _name;
        public string Name { get { return _name; } }

        private List<Card> _cardsInHand;
        public List<Card> CardsInHand { get { return _cardsInHand; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public Player(string name)
        {
            _name = name;
            _cardsInHand = new List<Card>();
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        #endregion

        #region Public Methods
        /// <summary>
        /// Add a card to hand
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddCardToHand(Card card)
        {
            if (card == null)
                throw new ArgumentNullException(nameof(card), "Card cannot be null");
            _cardsInHand.Add(card);
        }

        /// <summary>
        /// Remove a card from hand
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveCardFromHand(Card card)
        {
            if (card == null)
                throw new ArgumentNullException(nameof(card), "Card cannot be null");
            if (!_cardsInHand.Remove(card))
                throw new InvalidOperationException("Carte non trouvé dans les mains de "+_name);
        }
        #endregion


        #endregion
    }
}
