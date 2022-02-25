using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

namespace EmreErkanGames
{
    public class Nameplate : MonoBehaviour, INameplate
    {
        private Camera _camera;
        private Transform _cameraTransform;

        [Inject]
        public void Constructor(
            Camera camera
        )
        {
            _camera = camera;
            _cameraTransform = _camera.transform;
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                transform.LookAt(_camera.transform);
            });
        }

        public void SetHealtGauge(float value)
        {
            value = Mathf.Clamp01(value);
            transform.DOScale(new Vector3(3f * value, 1f, 1f), 0.1f);
        }
    }
}