using UnityEngine;

namespace Game.Physics
{
    public class RagdollBody : MonoBehaviour
    {
        [SerializeField] private RagdollBone[] bones;

        public void Activate()
        {
            foreach (var bone in bones)
            {
                bone.Activate();
            }
        }

        public void Deactivate()
        {
            foreach (var bone in bones)
            {
                bone.Deactivate();
            }
        }
    }
}
