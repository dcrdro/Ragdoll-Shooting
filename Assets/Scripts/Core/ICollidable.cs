using UnityEngine;

public interface ICollidable
{
    // add event ?
    
    LayerMask CollidableLayer { get; }
    void OnCollide();
}
