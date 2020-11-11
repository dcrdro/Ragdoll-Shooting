using System;
using Core.Fighting;
using Core.Fighting.Args;
using UnityEngine;

namespace Game.Physics
{
    public class SolidBody : MonoBehaviour, IForceable
    {
        [SerializeField] private Animator animator;

        [SerializeField] private Rigidbody2D solidRigidbody;
        [SerializeField] private Collider2D checkCollider;

        public event Action<IForceable, ForceArgs> ForceApplied;

        public Collider2D CheckCollider => checkCollider;

        public void ApplyForce(ForceArgs args)
        {
            solidRigidbody.AddForce(args.Force);
            ForceApplied?.Invoke(this, args);
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
}
