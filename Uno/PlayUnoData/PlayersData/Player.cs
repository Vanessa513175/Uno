using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PlayUnoData.UnoData;

namespace PlayUnoData.PlayersData
{
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
        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<Card> _cardsInHand;
        /// <summary>
        /// Get cards in hand
        /// </summary>
        public List<Card> CardsInHand
        {
            get { return _cardsInHand; }
            set { _cardsInHand = value; }
        }

        /// <summary>
        /// Count card in hand
        /// </summary>
        public int CardCount
        {
            get { return _cardsInHand.Count;}
        }

        private Guid _playerId;
        /// <summary>
        /// Player Id
        /// </summary>
        public Guid PlayerId
        {
            get { return _playerId; }
            set { _playerId = value; }  
        }
        #endregion

        #region Constructor
        public Player(string name)
        {
            _playerId = Guid.NewGuid();
            _name = name;
            _cardsInHand = new List<Card>();
        }
        #endregion

        #region Methods

        #region Private and Protected Methods
        #endregion

        #region Public Methods
        public void AddCard(Card card) 
        {
            _cardsInHand.Add(card);
        }

        public void RemoveCard(Card card) 
        {
            if (_cardsInHand.Contains(card)) 
            { 
                _cardsInHand.Remove(card);
            }
            else
            {
                Logger.Instance.Log(Logger.ELevelMessage.Error, "PLAYER : Impossible de supprimer une carte que le joueur n'a pas");
            }

        }
        #endregion

        #endregion

    }
}
