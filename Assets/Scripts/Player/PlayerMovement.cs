using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Run")]
    public float maxSpeed;
    [Range(0,1)]
    [Tooltip("walkSpeed is a percentage of maxSpeed set by your input value.")]
    public float walkSpeed;
    public float acceleration;
    public float deceleration;
    private float moveInput;

    [Header("Jump")]
    public float jumpForce;

    Rigidbody2D rb;
    bool isFlipped = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        walkSpeed = maxSpeed * walkSpeed;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }

        if(rb.velocity.x < 0 && !isFlipped){
            transform.Rotate(0,180,0);
            isFlipped = !isFlipped;
        }else if(rb.velocity.x > 0 && isFlipped){
            transform.Rotate(0,180,0);
            isFlipped = !isFlipped;
        }
    }

    void FixedUpdate(){
        float speed = Input.GetKey(KeyCode.LeftShift) ? maxSpeed : walkSpeed;
        float targetSpeed = speed * moveInput;
        float speedDifference = targetSpeed - rb.velocity.x;
        float rate = moveInput != 0 ? acceleration : deceleration;
        float movement = speedDifference * rate;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }
}
