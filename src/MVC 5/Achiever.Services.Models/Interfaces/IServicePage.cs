namespace Achiever.Services.Models
{
    public interface IServicePage
    {
        int Index { get; }
        int Size { get; }
        int Offset { get; }

        int LinqSkip { get; }
        int LinqTake { get; }
    }
}