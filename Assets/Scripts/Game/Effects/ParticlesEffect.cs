using Core.Effects;
using UnityEngine;

namespace Game.Effects
{
    public class ParticlesEffect : EffectBase
    {
        [SerializeField] private ParticleSystem particleSystem;
    
        public override void Play() => particleSystem.Play();
    }
}
