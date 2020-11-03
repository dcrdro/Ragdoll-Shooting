using UnityEngine;

namespace Core.Fighting.Args
{
    public struct DamageArgs
    {
        public GameObject Origin { get; } 
        public GameObject Dealer { get; }
        public float Damage { get; }

        public DamageArgs(GameObject origin, GameObject dealer, float damage)
        {
            Origin = origin;
            Dealer = dealer;
            Damage = damage;
        }
    }
}