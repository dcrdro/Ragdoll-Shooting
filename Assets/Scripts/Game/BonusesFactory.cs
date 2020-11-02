using UnityEngine;

public class BonusesFactory : MonoBehaviour, IFactory<int, GameObject>
{
    [SerializeField] private GameObject[] bonusesPrefabs;
    
    public GameObject Produce(int id) => Instantiate(bonusesPrefabs[id]);
    
    public int Size => bonusesPrefabs.Length;
}
