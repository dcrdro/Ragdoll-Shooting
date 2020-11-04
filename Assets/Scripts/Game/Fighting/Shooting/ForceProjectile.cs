using Core.Fighting;
using UnityEngine;

namespace Game.Fighting.Shooting
{
    public class ForceProjectile : MonoBehaviour, IProjectile
    {
        [SerializeField] private Rigidbody2D bulletRigidbody;
    
        public GameObject Origin { get; set; }

        public void Launch(Vector3 velocity) => bulletRigidbody.AddForce(velocity);
    }
}
