using System.Collections;
using UnityEngine;

public class SimpleBotController : FighterControllerBase
{
    private const float doubleJumpDelay = 0.5f;
        
    [SerializeField] private Vector2 jumpIntervalRange;
    [SerializeField, Range(0f, 1f)] private float doubleJumpChance;
    [SerializeField] private Vector2 shootIntervalRange;

    private float currentJumpInterval;
    private float currentShootInterval;
    
    private float jumpTick;
    private float shootTick;

    protected override void Init()
    {
        CalcJumpInterval();
        CalcShootInterval();
    }

    protected override void UpdateControl()
    {
        UpdateJump();
        UpdateShoot();
    }

    private void UpdateJump()
    {
        jumpTick += Time.deltaTime;
        if (jumpTick >= currentJumpInterval)
        {
            jumper.TryJump();
            if (Random.Range(0f, 1f) <= doubleJumpChance)
            {
                StartCoroutine(WaitForDoubleJump());
            }

            jumpTick = 0;
        }
    }

    private void UpdateShoot()
    {
        shootTick += Time.deltaTime;
        if (shootTick >= currentShootInterval)
        {
            weaponer.ApplyWeapon();
            shootTick = 0;
        }
    }

    private void CalcJumpInterval() => currentJumpInterval = Random.Range(jumpIntervalRange.x, jumpIntervalRange.y);
    private void CalcShootInterval() => currentShootInterval = Random.Range(shootIntervalRange.x, shootIntervalRange.y);

    private IEnumerator WaitForDoubleJump()
    {
        yield return new WaitForSeconds(doubleJumpDelay);
        jumper.TryJump();
    }
}
