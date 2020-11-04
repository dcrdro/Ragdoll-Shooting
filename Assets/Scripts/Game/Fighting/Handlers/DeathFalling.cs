using Core.Fighting;
using Core.Fighting.Args;
using Game.Physics;
using UnityEngine;

namespace Game.Fighting.Handlers
{
    public class DeathFalling : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour health; // as IHealth
        [SerializeField] private PhysicsSwitcher physicsSwitcher;

        public IHealth Health => (IHealth) health;

        private void OnEnable() => Health.Died += OnDied;
        private void OnDisable() => Health.Died -= OnDied;

        private void OnDied(DeathArgs obj) => physicsSwitcher.Switch(PhysicsState.Ragdoll);
    }
}
