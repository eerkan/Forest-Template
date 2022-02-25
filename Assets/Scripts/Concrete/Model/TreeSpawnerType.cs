using UnityEngine;

namespace EmreErkanGames
{
    [CreateAssetMenu(fileName = "New Tree Spawner Type", menuName = "Tree Spawner Type")]
    public class TreeSpawnerType : ScriptableObject
    {
        public float SpawnPeriodMilliseconds = 1f;
        public float SpawnRadius = 50f;
        public float OrbitPeriodSeconds = 1f;
        public float OrbitRadius = 50f;
    }
}