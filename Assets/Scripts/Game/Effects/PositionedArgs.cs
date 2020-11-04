using Core.Effects;
using UnityEngine;

namespace Game.Effects
{
    public readonly struct PositionedArgs : IEffectArgs
    {
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;

        public PositionedArgs(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}