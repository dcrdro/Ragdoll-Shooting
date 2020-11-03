using System;
using UnityEngine;

public class TriggerDamagable : MonoBehaviour, IDamagable
{
    [SerializeField] private MonoBehaviour damagable; // rework

    private IDamagable Damagable => (IDamagable) damagable;

    public event Action<IDamagable, DamageArgs> DamageTaken
    {
        add => Damagable.DamageTaken += value;
        remove => Damagable.DamageTaken -= value;
    }

    public void TakeDamage(DamageArgs args) => Damagable.TakeDamage(args);
}
