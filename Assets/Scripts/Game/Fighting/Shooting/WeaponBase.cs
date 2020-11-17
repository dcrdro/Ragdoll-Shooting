using System;
using Core.General;
using UnityEngine;

namespace Game.Fighting.Shooting
{
    public abstract class WeaponBase : MonoBehaviour, IOriginDerived
    {
        public event Action<GameObject> Shot;
        protected void NotifyShot(GameObject obj) => Shot?.Invoke(obj);
        
        public abstract void Shoot();
        public GameObject Origin { get; set; }
    }
}
