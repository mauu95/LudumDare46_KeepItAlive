using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10;
    public float speed = 400f;
    public GameObject GroundCheck;
    public LayerMask playerMask;

    private float horizontalMove = 0f;
    private Vector3 m_Velocity = Vector3.zero;
    private Rigidbody2D m_Rigidbody2D;
    public bool isGrounded = false;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        Move(horizontalMove * Time.fixedDeltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        isGrounded = Physics2D.Linecast(transform.position, GroundCheck.transform.position, playerMask);
    }


    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = targetVelocity;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            m_Rigidbody2D.velocity += jumpForce * Vector2.up;
            isGrounded = false;
        }
    }
}
