using System.Collections;
using UnityEngine;

public class TimedExplosion : MonoBehaviour
{
    [SerializeField] private ExplosionCollidable explosionCollidable;
    [SerializeField] private LifeTimer lifeTimer;

    void OnEnable() => lifeTimer.OnEnded += OnTimeEnded;
    void OnDisable() => lifeTimer.OnEnded -= OnTimeEnded;

    private void  OnTimeEnded() => explosionCollidable.OnCollide(null);
}
