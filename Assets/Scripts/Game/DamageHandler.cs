using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private MonoBehaviour health; // rework
    [SerializeField] private HitReceiver[] hitReceivers;
    
    private IDamagable Health => (IDamagable) health;

    private void Reset() => hitReceivers = GetComponentsInChildren<HitReceiver>();

    private void OnEnable()
    {
        foreach (var receiver in hitReceivers)
        {
            receiver.OnDamageTaken += OnDamageTaken;
        }        
    }

    private void OnDisable()
    {
        foreach (var receiver in hitReceivers)
        {
            receiver.OnDamageTaken -= OnDamageTaken;
        }        
    }

    private void OnDamageTaken(IDamagable source, float damage)
    {
        Health.TakeDamage(damage);
        HitboxID hitboxId = ((HitReceiver) source).HitboxID;
        print("on hit received: " + damage + ", " + hitboxId);
    }
}
