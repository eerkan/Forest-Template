using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using UniRx;

namespace EmreErkanGames
{
    public class TreeSpawner : MonoBehaviour, ITreeSpawner
    {
        private ITreePool _pool;
        private IMathUtility _mathUtility;
        private TreeSpawnerType _treeSpawnerType;

        [Inject]
        public void Constructor(
            ITreePool pool,
            IMathUtility mathUtility,
            TreeSpawnerType treeSpawnerType
        )
        {
            _pool = pool;
            _mathUtility = mathUtility;
            _treeSpawnerType = treeSpawnerType;

            SpawnAndMove();
        }

        private void SpawnAndMove()
        {
            Observable
                .Interval(TimeSpan.FromMilliseconds(_treeSpawnerType.SpawnPeriodMilliseconds))
                .Subscribe(_ => SpawnTree(_treeSpawnerType.SpawnRadius));

            Observable
                .EveryUpdate()
                .Subscribe(_ =>
                    {
                        transform.position = _mathUtility.CircularMovementXZ(_treeSpawnerType.OrbitRadius, 1f / _treeSpawnerType.OrbitPeriodSeconds, 0f, Time.time);
                    }
                );
        }

        private Vector3 GetSpawnTreePosition(float relativeSpawnRadius)
        {
            var treePosition = transform.position + relativeSpawnRadius * Random.insideUnitSphere;
            treePosition.y = 0f;
            return treePosition;
        }

        private void SpawnTree(float relativeSpawnRadius)
        {
            var tree = _pool.Spawn(GetSpawnTreePosition(relativeSpawnRadius));
        }
    }
}