using UnityEngine;

namespace Core.Effects
{
    public abstract class EffectBase<T> : MonoBehaviour, IEffect<T> where T : struct, IEffectArgs
    {
        public abstract void Play(in T args);
    }
}
