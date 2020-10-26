﻿using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExplosionCollidable : MonoBehaviour, ICollidable, IRootReference
{
    [SerializeField] private LayerMask explosionLayer;
    [SerializeField] private Transform explosionPoint;
    [SerializeField] private float explosionRadius; // move some field out of this class ?
    [SerializeField] private float damage;
    [SerializeField] private Vector2 explosionVelocity;
    [SerializeField] private GameObject rootObject;

    public GameObject RootObject => rootObject;

    public LayerMask CollidableLayer => explosionLayer;

    public void OnCollide()
    {
        IEnumerable<HitReceiver> receivers = Physics2D.OverlapCircleAll(explosionPoint.position, explosionRadius, explosionLayer)
            .Where(c => c.TryGetComponent<HitReceiver>(out _))
            .Select(c => c.GetComponent<HitReceiver>());

        SwitchRagdoll(receivers);
        ApplyHit(receivers);

        Destroy(RootObject);
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
                    switcher.Switch();
                }
            }
        }
    }

    private void ApplyHit(IEnumerable<HitReceiver> receivers)
    {
        foreach (var receiver in receivers)
        {
            receiver.TakeDamage(damage); // replace to IDamager ?
            Vector3 distance = receiver.transform.position - explosionPoint.position;
            float powerMultiplier = Mathf.InverseLerp(explosionRadius, 0, distance.magnitude);
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