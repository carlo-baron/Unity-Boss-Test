using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField]int maxHealth;
    int currentHealth;

    void Start(){
        currentHealth = maxHealth;
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
