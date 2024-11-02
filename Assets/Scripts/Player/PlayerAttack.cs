using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    [SerializeField]BoxCollider2D atkCollider;
    PlayerMovement playerMovement;
    int atkVal;
    public int AtkVal
    {
        get
        {
            return atkVal;
        }
        set
        {
            atkVal = value;
        }
    }
    
    bool reAttack = true;
    public bool ReAttack
    {
        get
        {
            return reAttack;
        }
        set
        {
            reAttack = value;
        }
    }
    
    bool isAttack = false;
    public bool IsAttack
    {
        get
        {
            return isAttack;
        }
        set
        {
            isAttack = value;
        }
    }

    int atkCache = 0;
    public int AtkCache
    {
        get
        {
            return atkCache;
        }
        set
        {
            atkCache = value;
        }
    }
    
    public Cooldown cd;
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && reAttack)
        {
            atkVal = atkVal == 0 ? 1 : atkCache;
            anim.SetTrigger("atk");
            reAttack = false;
            cd.StartCooldown();
        }

        anim.SetInteger("intVal", atkVal);
        anim.SetBool("inAtk", isAttack);

        playerMovement.enabled = reAttack ? true : false;

        if (isAttack) cd.StartCooldown();
        if (cd.isCoolingdown) return;
        atkVal = 0;
    }

    int AttackValueLogic(int num)
    {
        return num < 3 ? num + 1 : 1;
    }

    public void NextAttack()
    {
        atkVal = AttackValueLogic(atkVal);
        atkCache = atkVal;
    }

    public void CheckAttack()
    {
        if (!isAttack)
        {
            atkVal = 0;
        }
    }

    Collider2D[] EnemiesHit(){
        List<Collider2D> enemies = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(LayerMask.GetMask("enemy"));
        contactFilter.useTriggers = true;

        Physics2D.OverlapCollider(atkCollider, contactFilter, enemies);

        return enemies.ToArray();
    }

    // Damage parameter is set in the animation event
    public void Attack(int damage){
        if(EnemiesHit().Length > 0){
            foreach(Collider2D enemy in EnemiesHit()){
                IDamageable damageable = enemy.gameObject.GetComponent<IDamageable>();
                damageable?.Hurt(damage);

                if(enemy.tag == "projectile"){
                    enemy.GetComponent<Projectiles>().Ricochet();
                }
            }
        }
    }

    public void GiveKnockback(float multiplier){
        if(EnemiesHit().Length > 0){
            foreach(Collider2D enemy in EnemiesHit()){
                IDamageable damageable = enemy.gameObject.GetComponent<IDamageable>();
                damageable?.Knockback(transform, multiplier);
            }
        }
    }
}
