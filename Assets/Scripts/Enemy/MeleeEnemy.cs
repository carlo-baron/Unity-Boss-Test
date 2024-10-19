using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemy : Enemy
{
    [SerializeField] protected float distanceBeforeAttack;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Cooldown AttackCooldown;

    /// <summary>
    /// Move towards player until a certain a distance, and return true or false if moving or not
    /// </summary>
    /// <returns></returns>
    protected bool MoveTowardsPlayer()
    {
        if (DistanceToPlayer() > distanceBeforeAttack)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = new Vector2(player.position.x, currentPos.y);
            Vector2 newPos = Vector2.MoveTowards(currentPos, targetPos, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            return true;
        }
        else
        {
            return false;
        }
    }
}
