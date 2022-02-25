using UniRx;

namespace EmreErkanGames
{
    public interface IHealtController : IHealtable
    {
        public IReadOnlyReactiveProperty<float> CurrentHealt { get; }
    }
}
