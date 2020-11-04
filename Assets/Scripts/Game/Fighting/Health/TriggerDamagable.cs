using System;
using Core.Fighting;
using Core.Fighting.Args;
using UnityEngine;

namespace Game.Fighting.Health
{
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
}
