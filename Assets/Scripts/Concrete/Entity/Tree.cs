using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

namespace EmreErkanGames
{
    public partial class Tree : MonoBehaviour, ITree
    {
        private ITreePool _pool;
        private IHealtController _healtController;
        private Renderer _renderer;
        private bool _isKilled;

        [Inject]
        public void Constructor(
            ITreePool pool,
            IHealtController healtController,
            Renderer renderer
        )
        {
            _pool = pool;
            _healtController = healtController;
            _renderer = renderer;

            Colorize();
        }

        private void Colorize()
        {
            var materialPropertyBlock = new MaterialPropertyBlock();
            _healtController.CurrentHealt
                .Select(currentHealt =>
                    currentHealt < 0.15f ? 0.11f * (Vector2.left + Vector2.up)
                    : currentHealt < 0.3f ? 0.5f * Vector2.left
                    : Vector2.zero
                )
                .Subscribe(textureOffset =>
                    {

                        materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, textureOffset.x, textureOffset.y));
                        _renderer.SetPropertyBlock(materialPropertyBlock);
                    }
                );
        }

        public void Heal(float amount)
        {
            _healtController.Heal(amount);
        }

        public void Damage(float amount)
        {
            _healtController.Damage(amount);
        }

        public void Kill()
        {
            if (_isKilled) return;
            _isKilled = true;
            transform
                .DOScale(Vector3.zero, 0.3f)
                .OnComplete(() => _pool.Despawn(this));
        }

        public void Reset(Vector3 position)
        {
            transform.localPosition = position;
            Heal(1f);
            _isKilled = false;
            transform.DOScale(Vector3.one, 0.3f);
        }
    }
}