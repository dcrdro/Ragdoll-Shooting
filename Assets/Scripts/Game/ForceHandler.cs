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
            receiver.OnForceApplied += OnForceApplied;
        }        
    }

    private void OnDisable()
    {
        foreach (var receiver in hitReceivers)
        {
            receiver.OnForceApplied -= OnForceApplied;
        }
    }

    private void OnForceApplied(IForceable source, Vector3 force)
    {
        HitReceiver receiver = (HitReceiver)source;
        HitboxID hitboxId = receiver.HitboxID;
        var bone = receiver.GetComponent<RagdollBone>();
        bone.ApplyForce(force);
        print("on force received: " + hitboxId + ", " + force);
    }
}
