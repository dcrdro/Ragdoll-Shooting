using UnityEngine;

namespace Core.Interacting
{
    public interface ITriggerable
    {
        // add event ?

        LayerMask TriggerableLayer { get; }
        void OnTrigger(Collider2D collider);
    }
}
