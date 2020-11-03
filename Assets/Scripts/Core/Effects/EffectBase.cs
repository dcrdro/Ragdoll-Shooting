using UnityEngine;

namespace Core.Effects
{
    public abstract class EffectBase : MonoBehaviour, IEffect
    {
        public abstract void Play();
    }
}
