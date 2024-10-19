using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiBoss : MeleeEnemy
{
    void Update()
    {
        Flip();
        bool isMoving = MoveTowardsPlayer();
        anim.SetBool("run", isMoving);


        if(AttackCooldown.isCoolingdown) return;
        if(!isMoving){
            print("true");
            anim.SetTrigger("atk");
            AttackCooldown.StartCooldown();
        }
    }

}
