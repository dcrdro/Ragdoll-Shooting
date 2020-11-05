using Core.Effects;
using UnityEngine;

namespace Game.Effects
{
    public readonly struct ParentedArgs : IEffectArgs
    {
        public readonly Transform Parent;
        public readonly Vector3 Position;

        public ParentedArgs(Transform parent, Vector3 position)
        {
            Parent = parent;
            Position = position;
        }
    }
}