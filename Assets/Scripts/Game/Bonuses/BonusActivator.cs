using UnityEngine;

public class BonusActivator : MonoBehaviour
{
    [SerializeField] private Health selfHealth; // rework
    [SerializeField] private GameObject bonusPrefab;

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
        GameObject bonusTarget = deathArgs.Origin;
        if (bonusTarget.TryGetComponent<IAttachmentHolder>(out var attachmentHolder))
        {
            var instance = Instantiate(bonusPrefab, attachmentHolder.Holder);
            instance.transform.localPosition = Vector3.zero;
        }
        Destroy(gameObject);
    }    
}
