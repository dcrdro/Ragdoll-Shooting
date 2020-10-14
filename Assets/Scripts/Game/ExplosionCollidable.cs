using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExplosionCollidable : MonoBehaviour, ICollidable, IRootReference
{
    [SerializeField] private LayerMask explosionLayer;
    [SerializeField] private Transform explosionPoint;
    [SerializeField] private float explosionRadius; // move some field out of this class ?
    [SerializeField] private float damage;
    [SerializeField] private GameObject rootObject;

    public GameObject RootObject => rootObject;

    public LayerMask CollidableLayer => explosionLayer;

    public void OnCollide()
    {
        // refactor
        HitReceiver[] colliders = Physics2D.OverlapCircleAll(explosionPoint.position, explosionRadius, explosionLayer)
            .Select(c => c.GetComponent<HitReceiver>()).ToArray();
        if (colliders.Length > 0)
        {
            if (colliders[0].TryGetComponent<IRootReference>(out var root))
            {
                if (root.RootObject.TryGetComponent<PhysicsSwitcher>(out var switcher))
                {
                    switcher.Switch();
                }
            }
                
        }
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<IDamagable>(out var damagable))
            {
                damagable.TakeDamage(damage); // replace to IDamager ?
            }
        }
        Destroy(RootObject);
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(explosionPoint.position, explosionRadius);
    }
#endif
}
