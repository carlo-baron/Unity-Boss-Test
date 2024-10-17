using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecutiveAttack : StateMachineBehaviour
{
    PlayerAttack anim;
    bool canAttack = true;

    void Awake(){
        anim = FindObjectOfType<PlayerAttack>();
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        canAttack = true;
        anim.IsAttack = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Input.GetMouseButtonDown(0) && canAttack){
            anim.NextAttack();
            canAttack = false;
            anim.IsAttack = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!anim.IsAttack){
            anim.ReAttack = true;
            anim.AtkCache = anim.AtkCache < 3 ? anim.AtkVal + 1 : 1;
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
