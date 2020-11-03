using Core.UI;
using Game.Management;
using UnityEngine;

namespace Game.UI
{
    public class PauseButtonUI : UIBase
    {
        [SerializeField] private AppManager appManager;
    
        // UI Event
        public void OnPause() => appManager.PauseGame();
    }
}
