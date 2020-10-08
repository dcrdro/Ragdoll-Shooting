using UnityEngine;

public class PhysicsSwitcher : MonoBehaviour
{
    [SerializeField] private RagdollBody ragdollBody;
    [SerializeField] private SolidBody solidBody;

    [field:SerializeField]
    public bool IsRagdoll { get; private set; }

    void Start()
    {
        UpdatePhysicsState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Switch();
        }
    }
    
    public void Switch()
    {
        IsRagdoll = !IsRagdoll;
        UpdatePhysicsState(); 
    }

    private void UpdatePhysicsState()
    {
        if (IsRagdoll)
        {
            solidBody.Deactivate();
            ragdollBody.Activate();
        }
        else
        {
            ragdollBody.Deactivate();
            solidBody.Activate();
        }
    }
}
