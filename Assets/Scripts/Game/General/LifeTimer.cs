using System;
using Core.General;
using UnityEngine;

namespace Game.General
{
    public class LifeTimer : MonoBehaviour, ITimable
    {
        [SerializeField] private float lifeTime;

        private float remainTime;
        private bool isEnded;

        public float Capacity => lifeTime;
        public float Current => remainTime;
    
        public event Action Ended;

        private void Awake() => remainTime = lifeTime;

        // TODO: replace on update callback
        private void Update()
        {
            if (isEnded) return;
        
            remainTime -= Time.deltaTime;
            if (remainTime <= 0)
            {
                isEnded = true;
                Ended?.Invoke();
            }
        }
    }
}
