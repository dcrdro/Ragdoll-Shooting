using Core.Effects;
using UnityEngine;

namespace Game.Effects
{
    public class ParentedEffect : EffectBase<ParentedArgs>
    {
        [SerializeField] private EmptyEffect effect;
    
        public override void Play(in ParentedArgs args)
        {
            effect.transform.parent = args.Parent;
            effect.transform.position = args.Position;
            effect.Play(EmptyArgs.Empty);
        }
    }
}
