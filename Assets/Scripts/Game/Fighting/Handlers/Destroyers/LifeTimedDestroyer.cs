using UnityEngine;

public class LifeTimedDestroyer : MonoBehaviour
{
    [SerializeField] private LifeTimer lifeTimer;

    void OnEnable() => lifeTimer.Ended += OnTimeEnded;
    void OnDisable() => lifeTimer.Ended -= OnTimeEnded;

    private void OnTimeEnded() => Destroy(gameObject);
}
