using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRigidbody;
    [SerializeField] private float damage;

    public void Launch(Vector3 velocity)
    {
        bulletRigidbody.AddForce(velocity);
    }
}
