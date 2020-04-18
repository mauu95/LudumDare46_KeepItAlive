using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 10;
    public bool isGrounded;

    private Rigidbody2D m_Rigidbody2D;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(speed);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        m_Rigidbody2D.velocity += jumpForce * Vector2.up;
        isGrounded = false;
    }

    private void Move(float speed)
    {
        Vector3 targetVelocity = new Vector2(speed, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = targetVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
