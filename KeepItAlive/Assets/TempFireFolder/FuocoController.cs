using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuocoController : MonoBehaviour
{
    public ParticleSystem[] cose;
    private float[] coseStartSize;

    private void Start()
    {
        coseStartSize = new float[cose.Length];
        for (int i = 0; i < cose.Length; i++)
        {
            coseStartSize[i] = cose[i].startSize;
        }
    }

    public void SetIntensity(float intensity)
    {
        for (int i = 0; i < cose.Length; i++)
        {
            cose[i].startSize = coseStartSize[i] * intensity;
        }
    }
}
