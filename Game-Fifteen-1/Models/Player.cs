namespace GameFifteen.Models
{
    using System;
    using System.Linq;

    using Exceptions.PlayerExceptions;
    using Interfaces;

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
                if (value.All(char.IsLetter))
                {
                    if (!String.IsNullOrWhiteSpace(value))
                    {
                        this.name = value;
                    }
                    else
                    {
                        throw new InvalidPlayerNameException("The player name can not be empty.");
                    }
                }
                else
                {
                    throw new InvalidPlayerNameException("The name of the player should consist of only letters.");
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
                    throw new InvalidPlayerMovesException("The moves count can not be a negative number.");
                }

                this.moves = value;
            }
        }
        #endregion

        #region Methods
        public int CompareTo(object player) ////todo implement equals and use it here, and ovveride the toString()
        {
            var currentPlayer = (Player) player;
            var result = this.Moves.CompareTo(currentPlayer.Moves);
            return result;
        }
        #endregion
    }
}