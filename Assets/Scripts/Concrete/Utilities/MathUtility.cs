using UnityEngine;

namespace EmreErkanGames
{
    public class MathUtility : IMathUtility
    {
        public Vector3 CircularMovementXZ(float radius, float frequency, float phase, float time)
        {
            var radians = 2f * Mathf.PI * frequency * time + phase;
            return radius * new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));
        }
    }
}