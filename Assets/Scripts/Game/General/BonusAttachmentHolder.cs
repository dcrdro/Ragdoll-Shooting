using Core.General;
using UnityEngine;

namespace Game.General
{
    public class BonusAttachmentHolder : MonoBehaviour, IAttachmentHolder
    {
        [SerializeField] private Transform bonusHolder;

        public Transform Holder => bonusHolder;
    }
}
