using Core.Fighting;
using Game.Fighting.Shooting;
using Game.General;
using UnityEngine;

namespace Game.Control
{
    public abstract class FighterControllerBase : MonoBehaviour, IFighterController
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

        public abstract void Init();
        public abstract void UpdateControl();
    }
}
