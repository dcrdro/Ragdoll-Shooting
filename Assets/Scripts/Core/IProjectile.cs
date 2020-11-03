using UnityEngine;

public interface IProjectile : IOriginDerived
{
    void Launch(Vector3 velocity);
}
