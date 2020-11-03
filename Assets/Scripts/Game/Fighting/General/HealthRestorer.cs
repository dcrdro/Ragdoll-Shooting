using UnityEngine;

public class HealthRestorer : MonoBehaviour
{
    [SerializeField] private Health selfHealth; // rework
    [SerializeField] private float restoreAmount;

    private IHealth SelfHealth => (IHealth) selfHealth;

    private void OnEnable()
    {
        SelfHealth.Died += OnSelfDied;
    }

    private void OnDisable()
    {
        SelfHealth.Died -= OnSelfDied;
    }

    private void OnSelfDied(DeathArgs deathArgs)
    {
        RestoreHealth(deathArgs);
        Destroy(gameObject);
    }

    private void RestoreHealth(DeathArgs deathArgs)
    {
        GameObject restoreTarget = deathArgs.Origin;
        if (restoreTarget.TryGetComponent<IHealable>(out var healable))
        {
            healable.TakeHeal(new HealArgs(gameObject, gameObject, restoreAmount));
        }
    }
}
