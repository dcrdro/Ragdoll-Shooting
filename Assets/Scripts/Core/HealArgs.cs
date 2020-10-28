using UnityEngine;

public struct HealArgs
{
    public GameObject Origin { get; } 
    public GameObject Dealer { get; }
    public float Heal { get; }

    public HealArgs(GameObject origin, GameObject dealer, float heal)
    {
        Origin = origin;
        Dealer = dealer;
        Heal = heal;
    }
}