using UnityEngine;

public class BonusActivator : MonoBehaviour
{
    [SerializeField] private Health selfHealth; // rework

    private IHealth SelfHealth => (IHealth) selfHealth;

    private void OnEnable()
    {
        SelfHealth.OnDied += OnSelfDied;
    }

    private void OnDisable()
    {
        SelfHealth.OnDied -= OnSelfDied;
    }

    private void OnSelfDied(DeathArgs deathArgs)
    {
        // activate
        Destroy(gameObject);
    }    
}
