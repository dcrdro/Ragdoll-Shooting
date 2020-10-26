using System;
using UnityEngine;

public class SolidBody : MonoBehaviour, IForceable
{
    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody2D solidRigidbody;
    [SerializeField] private Collider2D checkCollider;

    public event Action<IForceable, Vector3> OnForceApplied;

    public Collider2D CheckCollider => checkCollider;

    public void ApplyForce(Vector3 force)
    {
        solidRigidbody.AddForce(force);
        OnForceApplied?.Invoke(this, force);
    }

    public void Stop() => solidRigidbody.velocity = Vector2.zero;

    public void Activate()
    {
        solidRigidbody.isKinematic = false;
        animator.enabled = true;
        checkCollider.enabled = true;
    }

    public void Deactivate()
    {
        solidRigidbody.isKinematic = true;
        checkCollider.enabled = false;
        animator.enabled = false;
    }
}
