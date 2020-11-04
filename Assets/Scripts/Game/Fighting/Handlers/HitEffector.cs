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
            PositionedArgs effectArgs = new PositionedArgs(receiver.transform.position, Quaternion.identity);
            PlayEffects(effectArgs);
        }
    }
}
