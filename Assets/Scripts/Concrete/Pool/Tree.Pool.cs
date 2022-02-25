using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Zenject;

namespace EmreErkanGames
{
    public partial class Tree
    {
        public class Pool : MemoryPool<Vector3, Tree>, ITreePool
        {
            private List<Tree> _trees = new();
            public ReadOnlyCollection<Tree> Trees => _trees.AsReadOnly();

            protected override void Reinitialize(Vector3 position, Tree tree)
            {
                tree.Reset(position);
            }

            protected override void OnSpawned(Tree tree)
            {
                _trees.Add(tree);
            }

            protected override void OnDespawned(Tree tree)
            {
                _trees.Remove(tree);
            }
        }
    }
}