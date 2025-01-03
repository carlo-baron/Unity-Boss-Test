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
        rb = !rb ? gameObject.AddComponent<Rigidbody2D>() : GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        walkSpeed = maxSpeed * walkSpeed;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }

        if(rb.linearVelocity.x < 0 && !isFlipped || rb.linearVelocity.x > 0 && isFlipped){
            transform.Rotate(0,180,0);
            isFlipped = !isFlipped;
        }
    }

    void FixedUpdate(){
        float speed = Input.GetKey(KeyCode.LeftShift) ? maxSpeed : walkSpeed;
        float targetSpeed = speed * moveInput;
        float speedDifference = targetSpeed - rb.linearVelocity.x;
        float rate = moveInput != 0 ? acceleration : deceleration;
        float movement = speedDifference * rate;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    public bool IsGrounded(){
        return Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("ground"));
    }
}
