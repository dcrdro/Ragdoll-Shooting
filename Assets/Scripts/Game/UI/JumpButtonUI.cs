using Core.UI;
using Game.General;
using UnityEngine;

namespace Game.UI
{
    public class JumpButtonUI : UIBase
    {
        [SerializeField] private Jumper jumper;
    
        // UI Event
        public void OnJump() => jumper.TryJump();
    }
}
