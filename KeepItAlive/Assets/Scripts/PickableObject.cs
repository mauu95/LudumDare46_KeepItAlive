using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour {

    public bool isGood = false;
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGood)
            explosion.GetComponent<ParticleSystem>().startColor = Color.green;
        else
            explosion.GetComponent<ParticleSystem>().startColor = Color.red;
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
