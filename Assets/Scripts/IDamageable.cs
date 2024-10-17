using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageable
{
    public void Hurt(int damage);
    public void Die();
}
