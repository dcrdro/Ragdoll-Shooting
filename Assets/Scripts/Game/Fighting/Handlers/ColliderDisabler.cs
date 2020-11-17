using System.Collections;
using Core.Effects;
using Game.Effects;
using Game.Interacting;
using UnityEngine;

namespace Game.Fighting.Handlers
{
    public class ColliderDisabler : MonoBehaviour
    {
        [SerializeField] private CollisionSender2D sender;
        [SerializeField] private Collider2D[] colliders;
        
        private void OnEnable()
        {
            sender.OnEnter += OnCollision;        
        }

        private void OnDisable()
        {
            sender.OnEnter -= OnCollision;        
        }
        
        private void OnCollision(Collision2D obj) => StartCoroutine(DisableColliders());

        private IEnumerator DisableColliders()
        {
            yield return null;
            
            foreach (var col in colliders)
            {
                col.enabled = false;
            }
            sender.OnEnter -= OnCollision;
        }
    }
}
