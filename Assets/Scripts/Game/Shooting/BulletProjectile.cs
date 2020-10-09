using UnityEngine;

public class BulletProjectile : MonoBehaviour, IDamager
{
    [SerializeField] private Rigidbody2D bulletRigidbody;
    [SerializeField] private float damage;

    public void Launch(Vector3 velocity)
    {
        bulletRigidbody.AddForce(velocity);
    }

    public void Damage(IHealth health)
    {
        health.UpdateHealth(-damage);
    }
}
