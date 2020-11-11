using System;
using Core.Fighting.Args;
using Game.Physics;
using UnityEngine;

namespace Game.General
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private SolidBody solidBody;
    
        [SerializeField] private float jumpSpeed = 1f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private int maxJumpsCount = 1;

        private int currentJumpsCount;

        private bool HasJumps() => currentJumpsCount < maxJumpsCount;
        private bool CanJump() => IsGrounded() || HasJumps();
        private bool IsGrounded() => Physics2D.BoxCast(solidBody.CheckCollider.bounds.center, solidBody.CheckCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer).collider;

        public event Action Jumped;

        [ContextMenu("Jump test")]
        public bool TryJump ()
        {
            if (CanJump())
            {
                PerformJump();
                return true;
            }

            return false;
        }

        private void PerformJump()
        {
            solidBody.Stop();
            solidBody.ApplyForce(new ForceArgs(null, null, Vector2.up * jumpSpeed));
            UpdateCount();
            Jumped?.Invoke();
        }

        private void UpdateCount()
        {
            if (IsGrounded()) currentJumpsCount = 1;
            else currentJumpsCount++;
        }
    }
}
