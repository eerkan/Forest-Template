using UniRx;
using UnityEngine;
using Zenject;

namespace EmreErkanGames
{
    public class HealtController : IHealtController
    {
        private INameplate _nameplate;
        private IKillable _killable;

        public ReactiveProperty<float> CurrentHealt { get; private set; }

        public HealtController(
            INameplate nameplate,
            IKillable killable,
            [Inject(Id = "StartingHealt")] float startingHealt
        )
        {
            _nameplate = nameplate;
            CurrentHealt = new(startingHealt);
            _killable = killable;

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
            CurrentHealt.Value = Mathf.Clamp01(CurrentHealt.Value + amount);
        }

        public void Damage(float amount)
        {
            CurrentHealt.Value = Mathf.Clamp01(CurrentHealt.Value - amount);
        }

        private void UpdateNameplate()
        {
            _nameplate.SetHealtGauge(CurrentHealt.Value);
        }
    }
}