using UnityEngine;

public class JumpButtonUI : UIBase
{
    [SerializeField] private Jumper jumper;
    
    // UI Event
    public void OnJump() => jumper.TryJump();
}
