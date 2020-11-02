using UnityEngine;

public class SoundEffect : EffectBase
{
    [SerializeField] private AudioSource audioSource;
    
    public override void Play() => audioSource.Play();
}
