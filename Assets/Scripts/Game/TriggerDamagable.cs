using System;
using UnityEngine;

public class TriggerDamagable : MonoBehaviour, IDamagable
{
    [SerializeField] private MonoBehaviour damagable; // rework

    private IDamagable Damagable => (IDamagable) damagable;

    public event Action<IDamagable, float> OnDamageTaken
    {
        add => Damagable.OnDamageTaken += value;
        remove => Damagable.OnDamageTaken -= value;
    }

    public void TakeDamage(float damage) => Damagable.TakeDamage(damage);
}
