using Core.Fighting;
using Core.Fighting.Args;
using Game.Fighting.Hitboxes;
using Game.Physics;
using UnityEngine;

namespace Game.Fighting.Handlers
{
    public class ForceHandler : MonoBehaviour
    {
        [SerializeField] private HitReceiver[] hitReceivers;
        [SerializeField] private HitboxConfigMapper hitboxMapper;
    
        private void Reset() => hitReceivers = GetComponentsInChildren<HitReceiver>();

        private void OnEnable()
        {
            foreach (var receiver in hitReceivers)
            {
                receiver.ForceApplied += OnForceApplied;
            }        
        }

        private void OnDisable()
        {
            foreach (var receiver in hitReceivers)
            {
                receiver.ForceApplied -= OnForceApplied;
            }
        }

        private void OnForceApplied(IForceable source, ForceArgs args)
        {
            HitReceiver receiver = (HitReceiver)source;
            HitboxID hitboxId = receiver.HitboxID;
            Vector3 totalForce = args.Force * hitboxMapper[hitboxId].ForceMultiplier;
        
            var bone = receiver.GetComponent<RagdollBone>();
            bone.ApplyForce(new ForceArgs(args.Origin, args.Dealer, totalForce));
        }
    }
}
