using Core.General;
using UnityEngine;

namespace Game.Interacting
{
    public class TriggerReceiver : MonoBehaviour, IRootReference
    {
        [SerializeField] private GameObject rootObject;

        public GameObject RootObject => rootObject;
    }
}
