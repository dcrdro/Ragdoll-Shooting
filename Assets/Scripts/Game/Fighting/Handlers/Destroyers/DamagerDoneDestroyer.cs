using Core.Fighting;
using UnityEngine;

namespace Game.Fighting.Handlers.Destroyers
{
    public class DamagerDoneDestroyer : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour damager; // IDamager

        private IDamager Damager => (IDamager) damager;

        private void OnEnable()
        {
            Damager.Damaged += OnDamaged;
        }

        private void OnDisable()
        {
            Damager.Damaged -= OnDamaged;
        }

        private void OnDamaged(IDamagable obj)
        {
            Destroy(gameObject);
        }
    }
}
