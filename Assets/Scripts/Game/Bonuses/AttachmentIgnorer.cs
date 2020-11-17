using System;
using Core.General;
using Game.Fighting.Shooting;
using UnityEngine;

namespace Game.Bonuses
{
    public class AttachmentIgnorer : MonoBehaviour, IOriginDerived
    {
        [SerializeField] private Collider2D[] attachmentColliders;
        
        public GameObject Origin { get; set; }

        private WeaponBase currentWeapon;
        
        private void Start()
        {
            currentWeapon = Origin.GetComponent<Weaponer>().Weapon;
            currentWeapon.Shot += OnShot;
        }

        private void OnDisable()
        {
            currentWeapon.Shot -= OnShot;
        }

        private void OnShot(GameObject instance)
        {
            Collider2D[] instanceColliders = instance.GetComponentsInChildren<Collider2D>();
            foreach (var instanceCollider in instanceColliders)
            {
                foreach (var attachmentCollider in attachmentColliders)
                {
                    Physics2D.IgnoreCollision(instanceCollider, attachmentCollider);
                }
            }
        }
    }
}