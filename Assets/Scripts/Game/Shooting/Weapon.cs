using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IOriginDerived
{
    public abstract void Shoot();
    public GameObject Origin { get; set; }
}
