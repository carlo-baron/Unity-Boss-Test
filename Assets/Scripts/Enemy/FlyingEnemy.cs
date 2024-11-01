using System;
using UnityEngine;

/// <summary>
/// Flying or Levitating enemies, will randomly choose one of the specified position of the developer to move or teleport to. After they may do other things.
/// </summary>
public class FlyingEnemy : Enemy
{
    [SerializeField] protected Transform[] SkyPosisitons;
    [SerializeField] protected Transform[] GroundPositions;
    [SerializeField] protected float MoveSpeed;
    [SerializeField] protected Cooldown AttackCooldown;
    [SerializeField] protected Cooldown ChangeStateCooldown;
    [SerializeField] protected GameObject Projectile;
    [SerializeField] protected Transform ProjectileFirePoint;

    protected enum AttackStates{
        SkyAttack,
        GroudAttack,
    }

    protected AttackStates RandomAttackState(){
        Array values = Enum.GetValues(typeof(AttackStates));
        int random = UnityEngine.Random.Range(0, values.Length);
        return (AttackStates)values.GetValue(random);
    }

    protected Vector3 RandomNewPosition(AttackStates state){
        switch(state){
            case AttackStates.SkyAttack:
                return SkyPosisitons[UnityEngine.Random.Range(0, SkyPosisitons.Length)].position;
            case AttackStates.GroudAttack:
                return GroundPositions[UnityEngine.Random.Range(0, GroundPositions.Length)].position;
        }

        return new Vector2();
    }

}
