using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;

public class LightControllor : MonoBehaviour {
    public float lightSize = 10f;
    public float lightSizeCap = 10f;
    public float timeBetweenGlowDown = 5f;

    private Light2D sceneLight;
    private float elapsedTime = 0;

    void Start() {
        sceneLight = GetComponent<Light2D>();
        sceneLight.pointLightOuterRadius = lightSize;
    }

    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeBetweenGlowDown) {
            lightSize -= 1;
            elapsedTime = 0;
        }
        sceneLight.pointLightOuterRadius = Mathf.Lerp(sceneLight.pointLightOuterRadius, lightSize, 5 * Time.deltaTime);
        // TODO: check for gameover
    }

    public void GotGoodStuff() {
        lightSize += 2;
        if (lightSize > lightSizeCap)
            lightSize = lightSizeCap;
        elapsedTime = 0;
    }

    public void GotBadStuff() {
        lightSize -= 2;

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Pickable")) {
            PickableObject po = collision.GetComponent<PickableObject>();
            if (po.isGood) GotGoodStuff();
            else GotBadStuff();
        }
    }
}
