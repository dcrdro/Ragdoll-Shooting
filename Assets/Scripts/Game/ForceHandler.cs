using System;
using UnityEngine;

public class ForceHandler : MonoBehaviour
{
    [SerializeField] private HitReceiver[] hitReceivers;
    [SerializeField] private HitboxConfigMapper hitboxMapper;
    
    private void Reset() => hitReceivers = GetComponentsInChildren<HitReceiver>();

    private void OnEnable()
    {
        foreach (var receiver in hitReceivers)
        {
            receiver.ForceApplied += OnForceApplied;
        }        
    }

    private void OnDisable()
    {
        foreach (var receiver in hitReceivers)
        {
            receiver.ForceApplied -= OnForceApplied;
        }
    }

    private void OnForceApplied(IForceable source, Vector3 force)
    {
        HitReceiver receiver = (HitReceiver)source;
        HitboxID hitboxId = receiver.HitboxID;
        Vector3 totalForce = force * hitboxMapper[hitboxId].ForceMultiplier;
        
        var bone = receiver.GetComponent<RagdollBone>();
        bone.ApplyForce(totalForce);
        print("on force received: " + hitboxId + ", " + totalForce);
    }
}
