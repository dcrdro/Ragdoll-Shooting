using UnityEngine;

namespace Game.Fighting.Handlers.Destroyers
{
    public class DelayedDestroyer : MonoBehaviour
    {
        [SerializeField] private float delay;

        private void Start()
        {
            Destroy(gameObject, delay);
        }
    }
}
