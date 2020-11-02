using System.Collections;
using UnityEngine;

public class LifeTimedDestroyer : MonoBehaviour
{
    [SerializeField] private LifeTimer lifeTimer;

    void OnEnable() => lifeTimer.OnEnded += OnTimeEnded;
    void OnDisable() => lifeTimer.OnEnded -= OnTimeEnded;

    private void OnTimeEnded() => Destroy(gameObject);
}
