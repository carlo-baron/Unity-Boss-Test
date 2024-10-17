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

    void Update()
    {
        velocityText.text = $"Velocity x: {playerRB.velocity.x:F2}, Velocity y: {playerRB.velocity.y:F2}";
        groundState.text = $"Ground State: {playerMovement.IsGrounded()}";
        animationState.text = $"Animation State: {playerAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name}";
    }
}
