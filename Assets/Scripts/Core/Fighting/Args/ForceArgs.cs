using UnityEngine;

namespace Core.Fighting.Args
{
    public struct ForceArgs
    {
        public GameObject Origin { get; } 
        public GameObject Dealer { get; }
        public Vector3 Force { get; }

        public ForceArgs(GameObject origin, GameObject dealer, Vector3 force)
        {
            Origin = origin;
            Dealer = dealer;
            Force = force;
        }
    }
}