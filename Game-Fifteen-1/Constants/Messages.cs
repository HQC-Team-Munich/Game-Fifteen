namespace GameFifteen.Constants
{
    public static class Messages
    {
        public const string Welcome =
            "Welcome to the game “15”. Please try to arrange the numbers sequentially. \nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' \nto quit the game.";

        public const string MoveInput = "Enter a number to move: ";

        public const string Lose = "Your matrix was solved by default :) Come on - NEXT try";

        public const string Win = "Congratulations! You won the game in {0} moves.";

        public const string HighScore = "Please enter your name for the top scoreboard: ";

        /* exception messages */
        public const string TileOutOfRangeExceptionMessage = "Invalid move! Valid moves range is [0-15]";

        public const string InvalidTileNeighbourExceptionMessage = "Invalid move! Please choose a valid neighbour!";

        public const string CommandIsNullExceptionMessage = "Invalid Command! Input can't be null.";

        public const string InvalidCommandExceptionMessage = "Invalid Command!\nYour input was not recognized as a valid command.";

        public const string InvalidPlayerNameExceptionMessage = "The player name can not be empty.";

        public const string InvalidPlayerMoveCountExceptionMessage = "The moves count can not be a negative number.";

        public const string InvalidTileLabelExceptionMessage = "The tile label should consist of only letters and digits.";

        public const string InvalidTilePositionExceptionMessage = "The position of the title can not be a negative number.";
    }
}