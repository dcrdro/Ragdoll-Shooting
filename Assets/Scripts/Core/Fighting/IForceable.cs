using System;
using Core.Fighting.Args;
using UnityEngine;

namespace Core.Fighting
{
    public interface IForceable
    {
        event Action<IForceable, ForceArgs> ForceApplied;
        void ApplyForce(ForceArgs forceArgs);
        void Stop();
    }
}
