using System.Collections.Generic;
using System.Linq;
using Core.General;
using Game.Fighting.Hitboxes;
using Game.Physics;
using UnityEngine;

namespace Game.Fighting.Damagers
{
    public class Exploder : MonoBehaviour, IOriginDerived
    {
        private const int minExplosionRadius = 4;
    
        [Header("Explosion")]
        [SerializeField] private LayerMask explosionLayer;
        [SerializeField] private Transform explosionPoint;
        [SerializeField] private float explosionRadius;
        [SerializeField] private Vector2 explosionVelocity;

        [Header("Damager")]
        [SerializeField] private ExplosionDamager explosionDamager;

        public GameObject Origin { get; set; }

        public LayerMask ExplosionLayer => explosionLayer;

        public void Explode()
        {
            IEnumerable<HitReceiver> receivers = Physics2D.OverlapCircleAll(explosionPoint.position, explosionRadius, explosionLayer)
                .Where(c => c.TryGetComponent<HitReceiver>(out _))
                .Select(c => c.GetComponent<HitReceiver>());

            SwitchRagdoll(receivers);
            ApplyHit(receivers);
        }

        private static void SwitchRagdoll(IEnumerable<HitReceiver> receivers)
        {
            // hack
            if (receivers.Count() > 0)
            {
                if (receivers.ElementAt(0).TryGetComponent<IRootReference>(out var root))
                {
                    if (root.RootObject.TryGetComponent<PhysicsSwitcher>(out var switcher))
                    {
                        switcher.Switch(PhysicsState.Ragdoll);
                    }
                }
            }
        }

        private void ApplyHit(IEnumerable<HitReceiver> receivers)
        {
            ApplyDamage(receivers);
            ApplyForce(receivers);
        }

        private void ApplyDamage(IEnumerable<HitReceiver> receivers)
        {
            explosionDamager.Origin = Origin;
            explosionDamager.Damage(receivers);
        }

        private void ApplyForce(IEnumerable<HitReceiver> receivers)
        {
            foreach (var receiver in receivers)
            {
                Vector3 distance = receiver.transform.position - explosionPoint.position;
                float powerMultiplier = Mathf.InverseLerp(explosionRadius, minExplosionRadius, distance.magnitude); // make via curve ?
                Vector3 force = distance.normalized * powerMultiplier * explosionVelocity;
                receiver.ApplyForce(force);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(explosionPoint.position, explosionRadius);
            Gizmos.color = Color.white;
        }
#endif
    }
}
