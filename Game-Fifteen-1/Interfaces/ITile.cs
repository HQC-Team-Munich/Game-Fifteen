namespace GameFifteen.Interfaces
{
    using System;

    public interface ITile : IComparable
    {
        int Position { get;  set; }
        string Label { get; }
    }
}
