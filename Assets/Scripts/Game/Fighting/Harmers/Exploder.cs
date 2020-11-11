using System;
using System.Collections.Generic;
using System.Linq;
using Core.Fighting.Args;
using Core.General;
using Game.Fighting.Hitboxes;
using Game.Physics;
using UnityEngine;

namespace Game.Fighting.Damagers
{
    public class Exploder : MonoBehaviour, IOriginDerived
    {
        private const float minExplosionRadiusMultiplier = 0.75f;
    
        [Header("Explosion")]
        [SerializeField] private LayerMask explosionLayer;
        [SerializeField] private Transform explosionPoint;
        [SerializeField, Tooltip("For more realistic explosion")] private Vector3 explosionPointOffset;
        [SerializeField] private float explosionRadius;
        [SerializeField] private float explosionVelocity;

        [Header("Damager")]
        [SerializeField] private ExplosionDamager explosionDamager;

        public GameObject Origin { get; set; }

        public LayerMask ExplosionLayer => explosionLayer;

        public Transform ExplosionPoint => explosionPoint;

        public event Action Exploded;

        public void Explode()
        {
            IEnumerable<HitReceiver> receivers = Physics2D.OverlapCircleAll(explosionPoint.position, explosionRadius, explosionLayer)
                .Where(c => c.TryGetComponent<HitReceiver>(out _))
                .Select(c => c.GetComponent<HitReceiver>());

            SwitchRagdoll(receivers);
            ApplyHit(receivers);
            Exploded?.Invoke();
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
                Vector3 distance = receiver.transform.position - (explosionPoint.position + explosionPointOffset);
                float minRadius = minExplosionRadiusMultiplier * explosionRadius;
                float powerMultiplier = Mathf.InverseLerp(explosionRadius, minRadius, distance.magnitude); // make via curve ?
                Vector3 force = distance.normalized * (powerMultiplier * explosionVelocity);
                receiver.ApplyForce(new ForceArgs(Origin, gameObject, force));
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(explosionPoint.position, explosionRadius);
            Gizmos.DrawWireSphere(explosionPoint.position + explosionPointOffset, 0.1f); // explosion real point
            Gizmos.color = Color.white;
        }
#endif
    }
}
