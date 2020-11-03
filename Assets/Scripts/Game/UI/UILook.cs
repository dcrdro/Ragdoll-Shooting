using UnityEngine;

namespace Game.UI
{
    public class UILook : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
