using UnityEngine;

namespace EmreErkanGames
{
    public interface ITree : IHealtable, IKillable
    {
        public void Reset(Vector3 position);
    }
}
