using UnityEngine;

public class BonusAttachmentHolder : MonoBehaviour, IAttachmentHolder
{
    [SerializeField] private Transform bonusHolder;

    public Transform Holder => bonusHolder;
}
