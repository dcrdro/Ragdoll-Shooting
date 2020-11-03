using Core.Fighting;
using Core.Fighting.Args;
using Game.Fighting.Hitboxes;
using UnityEngine;

namespace Game.Fighting.Handlers
{
    public class DamageHandler : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour health; // rework
        [SerializeField] private HitReceiver[] hitReceivers;
        [SerializeField] private HitboxConfigMapper hitboxMapper;
    
        private IDamagable Health => (IDamagable) health;

        private void Reset() => hitReceivers = GetComponentsInChildren<HitReceiver>();

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
            HitboxID hitboxId = ((HitReceiver) source).HitboxID;
            float totalDamage = args.Damage * hitboxMapper[hitboxId].DamageMultiplier;
            Health.TakeDamage(new DamageArgs(args.Origin, args.Dealer, totalDamage));
            print("on hit received: " + totalDamage + ", " + hitboxId);
        }
    }
}
