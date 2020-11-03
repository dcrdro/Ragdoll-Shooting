using Game.Fighting.Damagers;
using Game.General;
using UnityEngine;

namespace Game.Fighting.General
{
    public class TimedExplosion : MonoBehaviour
    {
        [SerializeField] private ExplosionCollidable explosionCollidable;
        [SerializeField] private LifeTimer lifeTimer;

        void OnEnable() => lifeTimer.Ended += OnTimeEnded;
        void OnDisable() => lifeTimer.Ended -= OnTimeEnded;

        private void  OnTimeEnded() => explosionCollidable.OnCollide(null);
    }
}
