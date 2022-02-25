using System.Collections.ObjectModel;
using UnityEngine;
using Zenject;

namespace EmreErkanGames
{
    public interface ITreePool : IMemoryPool<Vector3, Tree>
    {
        public ReadOnlyCollection<Tree> Trees { get; }
    }
}
