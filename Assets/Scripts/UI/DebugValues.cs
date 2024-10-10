using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugValues : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] TextMeshProUGUI velocityText;

    void Update()
    {
        velocityText.text = $"Velocity x: {playerRB.velocity.x}, Velocity y: {playerRB.velocity.y}";
    }
}
