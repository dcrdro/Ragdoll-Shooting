using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase
{
    [SerializeField] private BulletProjectile bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed;

    public override void Shoot()
    {
        BulletProjectile instance = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        instance.Origin = Origin;
        instance.Launch(shootPoint.right * bulletSpeed);
    }
}
