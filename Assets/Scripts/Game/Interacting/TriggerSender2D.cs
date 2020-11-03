using System;
using UnityEngine;

public class TriggerSender2D : MonoBehaviour
{
    public event Action<Collider2D> OnEnter;
    public event Action<Collider2D> OnExit;

    private void OnTriggerEnter2D(Collider2D collider) => OnEnter?.Invoke(collider);
    private void OnTriggerExit2D(Collider2D collider) => OnExit?.Invoke(collider);
}
