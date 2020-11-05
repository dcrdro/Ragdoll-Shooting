using Core.Effects;
using Core.Fighting;
using Core.Fighting.Args;
using Game.Effects;
using Game.Fighting.Damagers;
using Game.Fighting.Hitboxes;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.Fighting.Handlers
{
    public class ExplosionEffector : EffectorBase<ParentedArgs>
    {
        [SerializeField] private Exploder exploder;
    
        private void OnEnable()
        {
            exploder.Exploded += OnExploded;        
        }

        private void OnDisable()
        {
            exploder.Exploded -= OnExploded;        
        }

        private void OnExploded()
        {
            ParentedArgs args = new ParentedArgs(null, exploder.ExplosionPoint.position);
            PlayEffects(args);
        }
    }
}
