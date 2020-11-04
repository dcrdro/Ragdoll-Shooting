using System.Collections.Generic;
using Core.Fighting;
using UnityEngine;

namespace Game.Fighting.Handlers.Destroyers
{
    public class MultiTargetDamagerDoneDestroyer : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour damager; // as IMultiTargetDamager

        private IMultiTargetDamager Damager => (IMultiTargetDamager) damager;

        private void OnEnable()
        {
            Damager.Damaged += OnDamaged;
        }

        private void OnDisable()
        {
            Damager.Damaged -= OnDamaged;
        }

        private void OnDamaged(IEnumerable<IDamagable> damagables)
        {
            Destroy(gameObject);
        }
    }
}
