using UnityEngine;

public class DamagerTriggerable : MonoBehaviour, ITriggerable
{
    [SerializeField] private MonoBehaviour damager; // rework
    [SerializeField] private LayerMask damageMask;
    
    private IDamager Damager => (IDamager) damager;

    public LayerMask TriggerableLayer => damageMask;

    public void OnTrigger(Collider2D collider)
    {
        if (collider.TryGetComponent<IDamagable>(out var damagable))
        {
            Damager.Damage(damagable);
        }
    }
}
