using Core.General;
using Core.Interacting;
using UnityEngine;

namespace Game.Fighting.Damagers
{
    public class ExplosionCollidable : MonoBehaviour, ICollidable, IOriginDerived
    {
        [SerializeField] private Exploder exploder;

        public LayerMask CollidableLayer => exploder.ExplosionLayer;

        public GameObject Origin { get; set; }

        public void OnCollide(Collision2D collision) => exploder.Explode();
    }
}
