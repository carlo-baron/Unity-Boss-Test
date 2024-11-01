using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBoss : MonoBehaviour
{
    [SerializeField] Cooldown atkCD;
    public GameObject atkProjectile;
    Transform playerPos;
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("player").transform;
    }

    
    void Update()
    {
        if(atkCD.isCoolingdown) return;
        GameObject projectile = Instantiate(atkProjectile, transform.position, Quaternion.identity);
        Vector2 dir = (playerPos.position - transform.position).normalized;
        projectile.GetComponent<Projectiles>().Direction = dir;
        atkCD.StartCooldown();
    }
}
