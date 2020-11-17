using UnityEngine;

namespace Core.General
{
    public interface IAttachmentHolder
    {
        void Attach(Transform attachment, Vector3 position);
        Transform[] GetAttachments();
    }
}
