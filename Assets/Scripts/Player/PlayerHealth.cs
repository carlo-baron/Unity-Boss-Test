using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    [SerializeField] bool canKnockback;
    int currentHealth;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start(){
        currentHealth = maxHealth;
    }

    public void Knockback(Transform sender, float multiplier){
        if(canKnockback){
            Vector2 dir = transform.position - sender.position;
            rb?.AddForce(dir * multiplier, ForceMode2D.Impulse);
        }
    }

    public void Hurt(int damage){
        currentHealth -= damage;

        if(currentHealth <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
