using UnityEngine;

namespace Game.Effects
{
    public class DestroyEffect : EmptyEffect
    {
        [SerializeField] private EmptyEffect effect;
        [SerializeField] private float delay;
    
        public override void Play(in EmptyArgs args)
        {
            effect.Play(EmptyArgs.Empty);
            Destroy(effect.gameObject, delay);
        }
    }
}
