using UnityEngine;

public class PausePanelUI : UIBase
{
    [SerializeField] private AppManager appManager;
    
    // UI Event
    public void OnResume() => appManager.UnpauseGame();
    public void OnRestart() => appManager.RestartGame();
}
