using System;
using UnityEngine;

public class DamageDoneDestroyer : MonoBehaviour
{
    [SerializeField] private MonoBehaviour damager; // IDamager

    private IDamager Damager => (IDamager) damager;

    private void OnEnable()
    {
        Damager.OnDamaged += OnDamaged;
    }

    private void OnDisable()
    {
        Damager.OnDamaged -= OnDamaged;
    }

    private void OnDamaged(IDamagable obj)
    {
        Destroy(gameObject);
    }
}
