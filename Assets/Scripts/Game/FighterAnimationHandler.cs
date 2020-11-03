using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAnimationHandler : MonoBehaviour
{
    private readonly int jumpHash = Animator.StringToHash("Jump");
    private readonly int shootHash = Animator.StringToHash("Shoot");
    
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

    private void OnJumped() => animator.SetTrigger(jumpHash);
    private void OnAppliedWeapon() => animator.SetTrigger(shootHash);
}
