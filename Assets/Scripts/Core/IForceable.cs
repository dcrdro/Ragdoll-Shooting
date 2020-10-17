using System;
using UnityEngine;

public interface IForceable
{
    event Action<IForceable, Vector3> OnForceApplied;
    void ApplyForce(Vector3 force);
    void Stop();
}
