using Core.General;
using UnityEngine;

namespace Game.Fighting.Shooting
{
    public abstract class WeaponBase : MonoBehaviour, IOriginDerived
    {
        public abstract void Shoot();
        public GameObject Origin { get; set; }
    }
}
