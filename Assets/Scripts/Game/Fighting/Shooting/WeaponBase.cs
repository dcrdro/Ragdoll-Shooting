using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IOriginDerived
{
    public abstract void Shoot();
    public GameObject Origin { get; set; }
}
