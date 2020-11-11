using System.Collections.Generic;
using System.Linq;
using Core.Interacting;
using UnityEngine;

namespace Game.Interacting
{
    public class Triggerer : MonoBehaviour
    {
        [SerializeField] private TriggerSender2D trigger;
        [SerializeField] private MonoBehaviour[] triggerables; // as ITriggerable

        private IEnumerable<ITriggerable> Triggerables;
        
        private void Awake() => Triggerables = triggerables.OfType<ITriggerable>();

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
            foreach (var triggerable in Triggerables)
            {
                if ((triggerable.TriggerableLayer & 1 << collider.gameObject.layer) > 0)
                    triggerable.OnTrigger(collider);
            }
        }
    }
}
