using UnityEngine;

public class TriggerDamager : MonoBehaviour
{
    [SerializeField] private TriggerSender2D trigger;
    [SerializeField] private MonoBehaviour damager; // rework
    
    private IDamager Damager => (IDamager) damager;

    void OnEnable()
    {
        trigger.OnEnter += OnTrigger;
    }

    void OnDisable()
    {
        trigger.OnEnter -= OnTrigger;
    }

    private void OnTrigger(Collider2D obj)
    {
        if (obj.TryGetComponent<IDamagable>(out var damagable))
        {
            Damager.Damage(damagable);
        }
    }
}
