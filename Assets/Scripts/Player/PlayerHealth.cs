using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    [SerializeField] bool canKnockback;
    int currentHealth;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Knockback(Transform sender, float multiplier)
    {
        if (canKnockback)
        {
            Vector2 dir = transform.position - sender.position;
            rb?.AddForce(dir * multiplier, ForceMode2D.Impulse);
        }
    }

    public delegate void HurtHandler(object source, EventArgs args);
    public event HurtHandler IsHurt;

    protected virtual void OnHurt()
    {
        if (IsHurt != null)
        {
            IsHurt(this, EventArgs.Empty);
        }
    }

    public delegate void DeathHandler(object source, EventArgs args);
    public event HurtHandler IsDead;

    protected virtual void OnDeath()
    {
        if (IsHurt != null)
        {
            IsDead(this, EventArgs.Empty);
        }
    }
    public void Hurt(int damage)
    {
        currentHealth -= damage;
        OnHurt();
        if (currentHealth <= 0)
        {
            OnDeath();
            Invoke("Die", 5f);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
