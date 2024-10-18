using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageable
{
    public void Hurt(int damage);
    public void Knockback(Transform sender, float multiplier);
    public void Die();
}
