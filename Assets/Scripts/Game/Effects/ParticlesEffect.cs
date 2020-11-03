using UnityEngine;

public class ParticlesEffect : EffectBase
{
    [SerializeField] private ParticleSystem particleSystem;
    
    public override void Play() => particleSystem.Play();
}
