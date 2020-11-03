using UnityEngine;

public enum PhysicsState
{
    None = 0,
    Ragdoll,
    Solid
}

public class PhysicsSwitcher : MonoBehaviour
{
    [SerializeField] private RagdollBody ragdollBody;
    [SerializeField] private SolidBody solidBody;

    [field:SerializeField]
    public PhysicsState CurrentPhysicsState { get; private set; }

    void Start()
    {
        UpdatePhysicsState();
    }
    
    public void Switch(PhysicsState state)
    {
        if (CurrentPhysicsState == state) return;
        
        CurrentPhysicsState = state;
        UpdatePhysicsState(); 
    }

    private void UpdatePhysicsState()
    {
        switch (CurrentPhysicsState)
        {
            case PhysicsState.Ragdoll:
                solidBody.Deactivate();
                ragdollBody.Activate();
                break;
            case PhysicsState.Solid:
                ragdollBody.Deactivate();
                solidBody.Activate();
                break;
        }
    }
}
