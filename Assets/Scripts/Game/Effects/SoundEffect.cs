using Core.Effects;
using UnityEngine;

namespace Game.Effects
{
    public class SoundEffect : EffectBase
    {
        [SerializeField] private AudioSource audioSource;
    
        public override void Play() => audioSource.Play();
    }
}
