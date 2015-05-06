namespace GameFifteen.Interfaces
{
    using System;
    using Exceptions.PlayerExceptions;

    public interface IPlayer : IComparable
    {
        /// <summary>
        /// This property contains the name of the player in-game. 
        /// It is set during initialization and cannot be changed anymore.
        /// </summary>
        /// <exception cref="InvalidPlayerNameException">
        /// Thrown when the value null or whitespace.
        /// </exception>
       
        string Name { get; }

        /// <summary>
        /// Contains the current moves the player has made in order to complete the game. 
        /// This is used to determine the top players in the scoreboard.
        /// </summary>
        /// <exception cref="InvalidPlayerMoveCountException">
        /// Thrown when the value is a negative number.
        /// </exception>
        int Moves { get; }
    }
}
