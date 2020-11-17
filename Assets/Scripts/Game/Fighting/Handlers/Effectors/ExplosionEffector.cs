using Core.Effects;
using Game.Effects;
using Game.Fighting.Damagers;
using UnityEngine;

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
