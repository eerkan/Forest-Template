using System;
using System.Collections.ObjectModel;
using System.Linq;
using UniRx;

namespace EmreErkanGames
{
    public class TreeController : ITreeController
    {
        private ITreePool _pool;
        private ReadOnlyCollection<Tree> _trees;

        public TreeController(
            ITreePool pool
        )
        {
            _pool = pool;

            DamageAllTrees();
        }

        private void DamageAllTrees()
        {
            _trees = _pool.Trees;

            Observable
                .Interval(TimeSpan.FromSeconds(0.1f))
                .Subscribe(_ =>
                {
                    _trees
                        .ToList()
                        .ForEach(tree => tree.Damage(0.05f));
                });
        }
    }
}