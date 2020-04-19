using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;

public class LightControllor : MonoBehaviour {
    public float lightSize = 2f;
    public float lightSizeCap = 10f;
    public float timeBetweenGlowDown = 5f;

    public FuocoController fuoco;
    private Light2D sceneLight;
    private float elapsedTime = 0;

    void Start() {
        sceneLight = GetComponent<Light2D>();
        sceneLight.pointLightOuterRadius = lightSize;
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeBetweenGlowDown) {
            lightSize -= 1;
            elapsedTime = 0;
            AudioManager.instance.PlayPickedBadStuff();
        }
        sceneLight.pointLightOuterRadius = Mathf.Lerp(sceneLight.pointLightOuterRadius, lightSize, 5 * Time.deltaTime);
        if (sceneLight.pointLightOuterRadius < 0.5f) {
            GameManager.instance.EndGame();
        }

        fuoco.SetIntensity(lightSize / 10f);
    }

    public void GotGoodStuff() {
        lightSize += 2;
        if (lightSize > lightSizeCap)
            lightSize = lightSizeCap;
        elapsedTime = 0;
        AudioManager.instance.PlayPickedGoodStuff();
    }

    public void GotBadStuff() {
        lightSize -= 2;
        AudioManager.instance.PlayPickedBadStuff();
    }

    public void Collided() {
        lightSize -= 1;
        AudioManager.instance.PlayCollided();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Pickable")) {
            PickableObject po = collision.GetComponent<PickableObject>();
            if (po.isGood) GotGoodStuff();
            else GotBadStuff();
            Destroy(collision.gameObject);
        } else if (collision.CompareTag("Platform")) {
            Collided();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            Collided();
        }
    }
}
