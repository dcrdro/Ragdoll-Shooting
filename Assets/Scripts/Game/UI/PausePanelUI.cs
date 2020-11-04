using Core.UI;
using Game.Management;
using UnityEngine;

namespace Game.UI
{
    public class PausePanelUI : UIBase
    {
        [SerializeField] private AppManager appManager;
    
        // UI Event
        public void OnResume() => appManager.UnpauseGame();
        public void OnRestart() => appManager.RestartGame();
    }
}
