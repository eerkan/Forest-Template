using UniRx;

namespace EmreErkanGames
{
    public interface IHealtController : IHealtable
    {
        public ReactiveProperty<float> CurrentHealt { get; }
    }
}
