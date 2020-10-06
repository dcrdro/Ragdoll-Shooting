using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] ragdollRigidbody2Ds;
    [SerializeField] private HingeJoint2D[] ragdollHingeJoint2Ds;

    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody2D nonRagdollrigidbody2D;
    [SerializeField] private BoxCollider2D nonRagdollCollider2D;

    public bool IsRagdoll { get; private set; }

    private void Start()
    {
        SetActiveRagdoll(false);
    }

    public void SetActiveRagdoll(bool active)
    {
        SetActiveRagdollParts(active);
        SetActiveNonRagdollParts(active);
    }

    private void SetActiveRagdollParts(bool active)
    {
        foreach (var hj in ragdollHingeJoint2Ds)
        {
            hj.enabled = active;
        }
        foreach (var rb in ragdollRigidbody2Ds)
        {
            rb.isKinematic = !active;
        }
    }

    private void SetActiveNonRagdollParts(bool active)
    {
        nonRagdollrigidbody2D.isKinematic = active;
        nonRagdollCollider2D.enabled = !active;
        animator.enabled = !active;
    }

    public void Switch()
    {
        IsRagdoll = !IsRagdoll;
        SetActiveRagdoll(IsRagdoll);
    }
}
