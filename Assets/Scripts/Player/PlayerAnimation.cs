using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    PlayerMovement playerMovement;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float maxClamp = Input.GetKey(KeyCode.LeftShift) ? 1 : 0.5f;
        anim.SetFloat("xVelocity", Mathf.Clamp(rb.velocity.x, -maxClamp, maxClamp));
        anim.SetFloat("yVelocity", Mathf.Clamp(rb.velocity.y, -1, 1));
        anim.SetBool("ground", playerMovement.IsGrounded());
    }
}
