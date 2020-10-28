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

    private void OnDamageTaken(IDamagable source, DamageArgs args)
    {
        HitboxID hitboxId = ((HitReceiver) source).HitboxID;
        float totalDamage = args.Damage * hitboxMapper[hitboxId].DamageMultiplier;
        Health.TakeDamage(new DamageArgs(args.Origin, args.Dealer, totalDamage));
        print("on hit received: " + totalDamage + ", " + hitboxId);
    }
}
