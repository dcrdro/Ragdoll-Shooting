using UnityEngine;

namespace Game.Effects
{
    public class SoundEffect : EmptyEffect
    {
        [SerializeField] private AudioSource audioSource;
    
        public override void Play(in EmptyArgs args) => audioSource.Play();
    }
}
