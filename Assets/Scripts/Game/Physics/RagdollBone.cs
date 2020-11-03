using System;
using UnityEngine;

public class RagdollBone : MonoBehaviour, IForceable
{
    [SerializeField] private Rigidbody2D boneRigidbody;
    [SerializeField] private HingeJoint2D boneJoint;

    public event Action<IForceable, Vector3> ForceApplied;

    public void Activate()
    {
        boneRigidbody.isKinematic = false;
        if (boneJoint) boneJoint.enabled = true;
    }

    public void Deactivate()
    {
        boneRigidbody.isKinematic = true;
        if (boneJoint) boneJoint.enabled = false;
    }

    public void ApplyForce(Vector3 force)
    {
        boneRigidbody.AddForce(force);
        ForceApplied?.Invoke(this, force);
    }

    public void Stop() => boneRigidbody.velocity = Vector2.zero;
}
