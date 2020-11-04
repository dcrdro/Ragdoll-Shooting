using Core.General;
using UnityEngine;

namespace Core.Fighting
{
    public interface IProjectile : IOriginDerived
    {
        void Launch(Vector3 velocity);
    }
}
