using UnityEngine;

namespace Game.Effects
{
    public class ParticlesEffect : EmptyEffect
    {
        [SerializeField] private ParticleSystem particleSystem;
    
        public override void Play(in EmptyArgs args) => particleSystem.Play();
    }
}
