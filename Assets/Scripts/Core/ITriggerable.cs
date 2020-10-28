using UnityEngine;

public interface ITriggerable
{
    // add event ?

    LayerMask TriggerableLayer { get; }
    void OnTrigger(Collider2D collider);
}
