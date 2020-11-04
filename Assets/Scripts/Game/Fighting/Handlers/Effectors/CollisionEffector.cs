using Core.Effects;
using Game.Effects;
using Game.Interacting;
using UnityEngine;

namespace Game.Fighting.Handlers
{
    public class CollisionEffector : EffectorBase<PositionedArgs>
    {
        [SerializeField] private CollisionSender2D sender;
        private void OnEnable()
        {
            sender.OnEnter += OnCollision;        
        }

        private void OnDisable()
        {
            sender.OnEnter -= OnCollision;        
        }
        
        private void OnCollision(Collision2D obj)
        {
            PositionedArgs effectArgs = new PositionedArgs(obj.GetContact(0).point, Quaternion.identity);
            PlayEffects(effectArgs);
        }
    }
}
