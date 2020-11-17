using Core.General;
using UnityEngine;

namespace Game.Bonuses
{
    public class BonusAttachmentHolder : MonoBehaviour, IAttachmentHolder, IOriginDerived
    {
        [SerializeField] private Transform bonusHolder;

        public GameObject Origin { get; set; }
        
        public void Attach(Transform attachment, Vector3 position)
        {
            attachment.parent = bonusHolder;
            attachment.localPosition = position;
            
            foreach (var derived in attachment.GetComponentsInChildren<IOriginDerived>())
            {
                derived.Origin = Origin;
            }
        }

        public Transform[] GetAttachments()
        {
            Transform[] children = new Transform[bonusHolder.childCount];
            int i = 0;
            foreach (Transform child in bonusHolder)
            {
                children[i++] = child;
            }

            return children;
        }
    }
}
