using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    public Rigidbody2D playerRB;

    void Update() {
        if (playerRB)
        {
            var angle = 90 + (playerRB.velocity.y * 2);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}
