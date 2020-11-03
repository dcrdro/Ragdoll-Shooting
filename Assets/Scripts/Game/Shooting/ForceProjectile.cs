using System;
using UnityEngine;

public class ForceProjectile : MonoBehaviour, IProjectile, IOriginDerived
{
    [SerializeField] private Rigidbody2D bulletRigidbody;
    
    public GameObject Origin { get; set; }

    public void Launch(Vector3 velocity) => bulletRigidbody.AddForce(velocity);
}
