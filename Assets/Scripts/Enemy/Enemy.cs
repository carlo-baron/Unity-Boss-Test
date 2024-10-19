using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;
    protected Transform player;
    bool isFlipped;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    protected float DistanceToPlayer(){
        return Vector2.Distance(player.position, transform.position);
    }
    protected void Flip(){
        if(player.position.x < transform.position.x && !isFlipped || player.position.x > transform.position.x && isFlipped){
            transform.Rotate(0,180,0);
            isFlipped = !isFlipped;
        }
    }
}
