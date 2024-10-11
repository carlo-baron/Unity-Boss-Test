using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [SerializeField] float cooldownnTime;
    float nextFireTime;

    public bool isCoolingdown => Time.time < nextFireTime;
    public void StartCooldown() => nextFireTime = Time.time + cooldownnTime;
}
