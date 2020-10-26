using System;
using UnityEngine;

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

    public event Action OnJumped;

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
        solidBody.ApplyForce(Vector2.up * jumpSpeed);
        UpdateCount();
        OnJumped?.Invoke();
    }

    private void UpdateCount()
    {
        if (IsGrounded()) currentJumpsCount = 1;
        else currentJumpsCount++;
    }
}
