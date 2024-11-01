using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [SerializeField] float cooldownTime;

    public float CooldownTime{
        get { return cooldownTime; }
        set { if(value > 0) cooldownTime = value; }
    }
    float nextFireTime;

    public bool isCoolingdown => Time.time < nextFireTime;
    public void StartCooldown() => nextFireTime = Time.time + cooldownTime;
}
