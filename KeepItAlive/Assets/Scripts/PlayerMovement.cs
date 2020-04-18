using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5;
    public float jumpForce = 10;
    public float acceleration = 0.1f;

    private Rigidbody2D m_Rigidbody2D;

    private void Start() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Move(speed);
        if (Input.GetKey(KeyCode.Space))
            Jump();
        speed += acceleration * Time.deltaTime;
        //if (gameObject.transform.position.y < 0) {
        //    GameManager.instance.EndGame();
        //}
    }

    private void Jump() {
        m_Rigidbody2D.velocity += Time.deltaTime * jumpForce * Vector2.up;
    }

    private void Move(float speed) {
        Vector3 targetVelocity = new Vector2(speed, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = targetVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

    }
}
