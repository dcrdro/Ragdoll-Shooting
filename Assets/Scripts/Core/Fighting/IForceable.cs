using System;
using UnityEngine;

namespace Core.Fighting
{
    public interface IForceable
    {
        event Action<IForceable, Vector3> ForceApplied;
        void ApplyForce(Vector3 force);
        void Stop();
    }
}
