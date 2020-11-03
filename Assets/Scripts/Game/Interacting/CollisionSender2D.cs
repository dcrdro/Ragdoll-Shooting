using System;
using UnityEngine;

public class CollisionSender2D : MonoBehaviour
{
    public event Action<Collision2D> OnEnter;
    public event Action<Collision2D> OnExit;

    private void OnCollisionEnter2D(Collision2D collision) => OnEnter?.Invoke(collision);
    private void OnCollisionExit2D(Collision2D collision) => OnExit?.Invoke(collision);
}
