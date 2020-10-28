using UnityEngine;

public class OriginInitializator : MonoBehaviour
{
    [SerializeField] private GameObject origin;
    
    private void Awake()
    {
        IOriginDerived[] originDerivedObjects = GetComponentsInChildren<IOriginDerived>();
        foreach (var derived in originDerivedObjects)
        {
            derived.Origin = origin;
        }
    }
}
