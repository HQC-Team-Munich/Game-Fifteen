namespace GameFifteen.Interfaces
{
    using System;

    public interface IPlayer : IComparable
    {
        string Name { get; }

        int Moves { get; }
    }
}
