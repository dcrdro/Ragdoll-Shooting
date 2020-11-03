using UnityEngine;

public class ProjectileWeapon : WeaponBase
{
    [SerializeField] private MonoBehaviour projectile; // as IProjectile
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float projectileSpeed;

    public override void Shoot()
    {
        MonoBehaviour instance = Instantiate(projectile, shootPoint.position, Quaternion.identity);
        foreach (var derived in instance.GetComponentsInChildren<IOriginDerived>())
        {
            derived.Origin = Origin;
        }
        ((IProjectile) instance).Launch(shootPoint.right * projectileSpeed);
    }
}
