using UniRx;
using UnityEngine;
using Zenject;

namespace EmreErkanGames
{
    public class HealtController : IHealtController
    {
        private INameplate _nameplate;
        private IKillable _killable;
        private ReactiveProperty<float> _currentHealt;

        public ReadOnlyReactiveProperty<float> CurrentHealt { get; }

        public HealtController(
            INameplate nameplate,
            IKillable killable,
            [Inject(Id = "StartingHealt")] float startingHealt
        )
        {
            _nameplate = nameplate;
            _currentHealt = new(startingHealt);
            _killable = killable;

            CurrentHealt = _currentHealt.ToReadOnlyReactiveProperty();

            ObserveCurrentHealt();
        }

        private void ObserveCurrentHealt()
        {
            CurrentHealt
                .Where(currentHealt => Mathf.Approximately(currentHealt, 0f))
                .Subscribe(_ => _killable.Kill());

            CurrentHealt.Subscribe(_ => UpdateNameplate());
        }

        public void Heal(float amount)
        {
            _currentHealt.Value = Mathf.Clamp01(CurrentHealt.Value + amount);
        }

        public void Damage(float amount)
        {
            _currentHealt.Value = Mathf.Clamp01(CurrentHealt.Value - amount);
        }

        private void UpdateNameplate()
        {
            _nameplate.SetHealtGauge(CurrentHealt.Value);
        }
    }
}