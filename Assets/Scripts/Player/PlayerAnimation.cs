using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    PlayerMovement playerMovement;
    float atkVal = 1;
    private bool canAttack;
    public bool CanAttack{
        get{
            return canAttack;
        }

        set{
            canAttack = value;
        }
    }
    [SerializeField] Cooldown atkResetCooldown;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        canAttack = true;
    }

    void Update()
    {
        float maxClamp = Input.GetKey(KeyCode.LeftShift) ? 1 : 0.5f;
        anim.SetFloat("xVelocity", Mathf.Clamp(rb.velocity.x, -maxClamp, maxClamp));
        anim.SetFloat("yVelocity", Mathf.Clamp(rb.velocity.y, -1, 1));
        anim.SetBool("ground", playerMovement.IsGrounded());
        anim.SetFloat("attackVal", atkVal);

        if(Input.GetMouseButtonDown(0) && canAttack){
            if(atkResetCooldown.isCoolingdown) {
                atkVal = atkVal < 3 ? atkVal+1 : 1;
            }else{
                atkVal = 1;
            }
            atkResetCooldown.StartCooldown();
            anim.SetTrigger("atk");
        }
    }
}
