using UnityEngine;

public abstract class FighterControllerBase : MonoBehaviour
{
    [SerializeField] protected Jumper jumper;
    [SerializeField] protected Weaponer weaponer;
    
    void Start()
    {
        Init();
    }

    void Update()
    {
        UpdateControl();
    }

    protected abstract void Init();
    protected abstract void UpdateControl();
}
