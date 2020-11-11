using System;
using Core.Fighting;
using Core.Fighting.Args;
using Core.General;
using UnityEngine;

namespace Game.Fighting.Damagers
{
    public class Forcer : MonoBehaviour, IForcer, IOriginDerived
    {
        [SerializeField] private float force;
        [SerializeField] private Transform viewRoot;

        private Vector3 ForceDirection => viewRoot.right;
        
        public event Action<IForcer> Forced;
        
        public GameObject Origin { get; set; }

        public void Force(IForceable forceable)
        {
            forceable.ApplyForce(new ForceArgs(Origin, gameObject, ForceDirection * force));
            Forced?.Invoke(this);
        }
    }
}
