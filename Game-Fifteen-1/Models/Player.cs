namespace GameFifteen.Models
{
    using System;

    using Constants;
    using GameFifteen.Exceptions.PlayerExceptions;
    using GameFifteen.Interfaces;

    public class Player : IPlayer
    {
        /// <summary>
        /// Player Class
        /// </summary>
        #region Fields
        private string name;
        private int moves;
        #endregion

        #region Constructors
        public Player(string name, int moves)
        {
            this.Name = name;
            this.Moves = moves;
        }
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new InvalidPlayerNameException(Messages.InvalidPlayerNameExceptionMessage);
                }
            }
        }

        public int Moves
        {
            get
            {
                return this.moves;
            }

            private set
            {
                if (value < 0)
                {
                    throw new InvalidPlayerMoveCountException(Messages.InvalidPlayerMoveCountExceptionMessage);
                }

                this.moves = value;
            }
        }
        #endregion

        #region Methods
        public int CompareTo(object player)
        {
            var currentPlayer = (Player) player;
            var result = this.Moves.CompareTo(currentPlayer.Moves);
            return result;
        }
        #endregion
    }
}