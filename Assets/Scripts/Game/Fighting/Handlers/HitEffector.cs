using Core.Effects;
using Core.Fighting;
using Core.Fighting.Args;
using Game.Effects;
using Game.Fighting.Hitboxes;
using UnityEngine;

namespace Game.Fighting.Handlers
{
    public class HitEffector : EffectorBase<PositionedArgs>
    {
        [SerializeField] private HitReceiver[] hitReceivers;
        [SerializeField] private GameObject rootObject;
    
        private void OnValidate() => hitReceivers = rootObject.GetComponentsInChildren<HitReceiver>();

        private void OnEnable()
        {
            foreach (var receiver in hitReceivers)
            {
                receiver.DamageTaken += OnDamageTaken;
            }        
        }

        private void OnDisable()
        {
            foreach (var receiver in hitReceivers)
            {
                receiver.DamageTaken -= OnDamageTaken;
            }        
        }

        private void OnDamageTaken(IDamagable source, DamageArgs args)
        {
            HitReceiver receiver = (HitReceiver) source;
            float angle = Vector3.Angle(args.Dealer.transform.position, receiver.transform.position);
            var inverseRotation = Quaternion.Euler(0, 0, angle - 180);
            PositionedArgs effectArgs = new PositionedArgs(receiver.transform.position,  inverseRotation);
            PlayEffects(effectArgs);
        }
    }
}
