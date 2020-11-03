using Core.Fighting;
using Core.Fighting.Args;
using Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class HealthUI : UIBase
    {
        [SerializeField] private MonoBehaviour health; // as IHealth

        [SerializeField] private Slider healthSlider;

        private IHealth Health => (IHealth) health;

        private void Start() => UpdateHealthUI();

        private void OnEnable()
        {
            Health.DamageTaken += OnDamageTaken;
            Health.HealTaken += OnHealTaken;
        }

        private void OnDisable()
        {
            Health.DamageTaken -= OnDamageTaken;
            Health.HealTaken -= OnHealTaken;
        }

        private void OnDamageTaken(IDamagable damagable, DamageArgs args) => UpdateHealthUI();
        private void OnHealTaken(IHealable healable, HealArgs args) => UpdateHealthUI();

        private void UpdateHealthUI()
        {
            float part = Health.HealthAmount / Health.MaxHealthAmount;
            healthSlider.value = part;
        }
    }
}
