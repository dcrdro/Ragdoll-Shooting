using Core.Interacting;
using UnityEngine;

namespace Game.Interacting
{
    public class Triggerer : MonoBehaviour
    {
        [SerializeField] private TriggerSender2D trigger;
        [SerializeField] private MonoBehaviour triggerable; // as ITriggerable

        private ITriggerable Triggerable => (ITriggerable) triggerable;

        void OnEnable()
        {
            trigger.OnEnter += OnEnter;
        }

        void OnDisable()
        {
            trigger.OnEnter -= OnEnter;
        }

        private void OnEnter(Collider2D collider)
        {
            if ((Triggerable.TriggerableLayer & 1 << collider.gameObject.layer) > 0)

                Triggerable.OnTrigger(collider);
        }
    }
}
