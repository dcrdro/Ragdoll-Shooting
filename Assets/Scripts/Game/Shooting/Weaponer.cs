using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Weaponer : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    public event Action OnAppliedWeapon;
    
    [ContextMenu("ApplyWeapon test")]
    public void ApplyWeapon()
    {
        weapon.Shoot();
        OnAppliedWeapon?.Invoke();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ApplyWeapon();
        }
    }
}
