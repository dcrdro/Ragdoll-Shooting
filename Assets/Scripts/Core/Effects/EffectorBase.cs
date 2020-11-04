using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Effects
{
    public abstract class EffectorBase<T> : MonoBehaviour where T : struct, IEffectArgs
    {
        [SerializeField] private MonoBehaviour[] _effects; // as IEffect
        
        private IEnumerable<EffectBase<T>> effects;

        private void Awake() => effects = _effects.OfType<EffectBase<T>>();

        protected void PlayEffects(in T args)
        {
            foreach (var effect in effects)
            {
                effect.Play(args);
            }
        }
    }
}