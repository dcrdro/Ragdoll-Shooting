using Core.Effects;
using UnityEngine;

namespace Game.Effects
{
    public class PositionedEffect : EffectBase<PositionedArgs>
    {
        [SerializeField] private EmptyEffect effect;
    
        public override void Play(in PositionedArgs args)
        {
            effect.transform.SetPositionAndRotation(args.Position, args.Rotation);
            effect.Play(EmptyArgs.Empty);
        }
    }
}
