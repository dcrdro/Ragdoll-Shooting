using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Weaponer : MonoBehaviour, IOriginDerived
{
    [SerializeField] private Weapon weapon;

    public GameObject Origin { get; set; }
    
    public event Action OnAppliedWeapon;

    private void Start()
    {
        weapon.Origin = Origin;
    }

    [ContextMenu("ApplyWeapon test")]
    public void ApplyWeapon()
    {
        weapon.Shoot();
        OnAppliedWeapon?.Invoke();
    }
}
