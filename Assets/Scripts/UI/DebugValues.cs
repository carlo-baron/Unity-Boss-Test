using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugValues : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] Animator playerAnim;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerAnimation playerAnimationController;
    [SerializeField] TextMeshProUGUI velocityText;
    [SerializeField] TextMeshProUGUI groundState;
    [SerializeField] TextMeshProUGUI animationState;
    [SerializeField] TextMeshProUGUI canAtk;

    void Update()
    {
        velocityText.text = $"Velocity x: {playerRB.velocity.x}, Velocity y: {playerRB.velocity.y}";
        groundState.text = $"Ground State: {playerMovement.IsGrounded()}";
        animationState.text = $"Animation State: {playerAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name}";
        canAtk.text = $"Can Attack: {playerAnimationController.CanAttack}";
    }
}
