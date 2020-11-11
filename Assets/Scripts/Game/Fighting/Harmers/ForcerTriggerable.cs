using Core.Fighting;
using Core.Interacting;
using UnityEngine;

namespace Game.Fighting.Damagers
{
    public class ForcerTriggerable : MonoBehaviour, ITriggerable
    {
        [SerializeField] private MonoBehaviour forcer; // rework
        [SerializeField] private LayerMask forceMask;
    
        private IForcer Forcer => (IForcer) forcer;

        public LayerMask TriggerableLayer => forceMask;

        public void OnTrigger(Collider2D collider)
        {
            if (collider.TryGetComponent<IForceable>(out var forceable))
            {
                Forcer.Force(forceable);
            }
        }
    }
}
