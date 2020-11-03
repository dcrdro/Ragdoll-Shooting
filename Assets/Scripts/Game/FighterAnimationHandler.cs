using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    [SerializeField] private Jumper jumper;
    [SerializeField] private Weaponer weaponer;
    
    private void OnEnable()
    {
        jumper.OnJumped += OnJumped;
        weaponer.OnAppliedWeapon += OnAppliedWeapon;
    }

    private void OnDisable()
    {
        jumper.OnJumped -= OnJumped;
        weaponer.OnAppliedWeapon -= OnAppliedWeapon;
    }

    private void OnJumped() => animator.SetTrigger("Jump");
    private void OnAppliedWeapon() => animator.SetTrigger("Shoot");
}
