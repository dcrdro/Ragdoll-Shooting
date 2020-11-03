using UnityEngine;

public class PauseButtonUI : UIBase
{
    [SerializeField] private AppManager appManager;
    
    // UI Event
    public void OnPause() => appManager.PauseGame();
}
