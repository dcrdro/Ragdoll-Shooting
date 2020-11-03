using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : WeaponBase
{
    [SerializeField] private MonoBehaviour projectile; // as IProjectile
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float projectileSpeed;

    public override void Shoot()
    {
        IProjectile instance = Instantiate(projectile, shootPoint.position, Quaternion.identity) as IProjectile;
        instance.Origin = Origin;
        instance.Launch(shootPoint.right * projectileSpeed);
    }
}
