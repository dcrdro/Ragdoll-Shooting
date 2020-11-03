using System;
using UnityEngine;

public class Weaponer : MonoBehaviour, IOriginDerived
{
    [SerializeField] private WeaponBase weapon;

    public GameObject Origin { get; set; }
    
    public event Action WeaponApplied;

    private void Start()
    {
        weapon.Origin = Origin;
    }

    [ContextMenu("ApplyWeapon test")]
    public void ApplyWeapon()
    {
        weapon.Shoot();
        WeaponApplied?.Invoke();
    }
}
