using UnityEngine;

public class TriggerDamager : MonoBehaviour
{
    [SerializeField] private TriggerSender2D trigger;
    [SerializeField] private MonoBehaviour damager;
    
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
        if (obj.TryGetComponent<IRootReference>(out var root))
        {
            if (root.RootObject.TryGetComponent<IHealth>(out var health))
            {
                Damager.Damage(health);
            }
        }
    }
}
