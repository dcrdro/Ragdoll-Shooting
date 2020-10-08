using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponer : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    [ContextMenu("ApplyWeapon test")]
    public void ApplyWeapon()
    {
        weapon.Shoot();
    }
}
