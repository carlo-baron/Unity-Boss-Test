using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBoss : FlyingEnemy
{
    AttackStates state;
    Vector3 newPosition;
    bool moveAgain = true;

    float defaultAttackCooldown;

    void Start(){
        defaultAttackCooldown = AttackCooldown.CooldownTime;
    }
    void Update()
    {
        Flip();
        anim.SetBool("flying", !moveAgain);
        if (ChangeStateCooldown.isCoolingdown)
        {
            if (state == AttackStates.SkyAttack)
            {
                AttackCooldown.CooldownTime = defaultAttackCooldown;
                Attack(AttackTowardsPlayer());
            }
            else if (state == AttackStates.GroudAttack)
            {
                AttackCooldown.CooldownTime = 0.5f;
                Vector3 groundAttackPosition = AttackTowardsPlayer() * Vector2.right;
                Attack(groundAttackPosition);
            }
            return;
        }
        if (moveAgain)
        {
            NewState();
            moveAgain = false;
        }
        MoveToNewPos();
    }

    void NewState()
    {
        state = RandomAttackState();
        Vector3 nextPosition;

        do
        {
            nextPosition = RandomNewPosition(state);
        } while (nextPosition == newPosition);

        newPosition = nextPosition;
    }


    void MoveToNewPos()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosition, MoveSpeed * Time.deltaTime);
        if (Mathf.Abs(Vector2.Distance(transform.position, newPosition)) <= 0.01)
        {
            ChangeStateCooldown.StartCooldown();
            moveAgain = true;
        }
    }

    void Attack(Vector3 dir)
    {
        if (AttackCooldown.isCoolingdown) return;
        anim.SetTrigger("atk");
        GameObject projectile = Instantiate(Projectile, ProjectileFirePoint.position, Quaternion.identity, transform);
        projectile.GetComponent<Projectiles>().Direction = dir;
        AttackCooldown.StartCooldown();
    }

    Vector3 AttackTowardsPlayer()
    {
        Vector3 playerCenter = player.gameObject.GetComponent<Collider2D>().bounds.center;
        return (playerCenter - transform.position).normalized;
    }
}
