using UnityEngine;

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
        HitboxID hitboxId = ((HitReceiver) source).HitboxID;
        float totalDamage = damage * hitboxMapper[hitboxId].DamageMultiplier;
        Health.TakeDamage(totalDamage);
        print("on hit received: " + totalDamage + ", " + hitboxId);
    }
}
