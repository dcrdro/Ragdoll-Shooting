using UnityEngine;

public class TriggerReceiver : MonoBehaviour, IRootReference
{
    [SerializeField] private GameObject rootObject;

    public GameObject RootObject => rootObject;
}
