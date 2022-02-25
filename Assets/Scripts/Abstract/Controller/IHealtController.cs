using UniRx;

namespace EmreErkanGames
{
    public interface IHealtController : IHealtable
    {
        public ReadOnlyReactiveProperty<float> CurrentHealt { get; }
    }
}
