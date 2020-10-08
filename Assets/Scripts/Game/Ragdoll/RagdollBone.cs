using UnityEngine;

public class RagdollBone : MonoBehaviour
{
    [SerializeField] private Rigidbody2D boneRigidbody;
    [SerializeField] private HingeJoint2D boneJoint;
    
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
}
