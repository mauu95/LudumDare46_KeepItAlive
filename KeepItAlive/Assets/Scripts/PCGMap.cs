using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGMap : MonoBehaviour
{
    public int seed;
    public Transform player;
    public GameObject background;
    public GameObject goodPickable;
    public GameObject badPickable;
    public GameObject platformPrefab;

    private IteratorSeed iseed;
    private int difficulty;
    private int counter;
    private GameObject map;

    private void Start()
    {
        iseed = new IteratorSeed(seed);
        map = CreateEmptyGameObject("map");
        CreateChunk(0);
    }

    private void Update()
    {
        int current = Mathf.FloorToInt(player.position.x / 100);
        if(current >= counter)
        {
            CreateChunk(++counter);
        }
    }

    private void CreateChunk(int nChunk)
    {
        GameObject currentChunk = CreateEmptyGameObject("Chunk" + counter.ToString());
        currentChunk.transform.position = new Vector3(nChunk * 100, 0f);
        currentChunk.transform.SetParent(map.transform);

        Instantiate(background, new Vector3(nChunk*100, 0f), Quaternion.identity ,currentChunk.transform);
        CreatePlatform(0f, 8f, 40f, currentChunk.transform);

    }

    private void CreatePlatform(float x, float y, float length, Transform parent)
    {
        GameObject temp = Instantiate(platformPrefab, new Vector3(x + length/2 + parent.position.x, y), Quaternion.identity, parent);
        temp.transform.localScale = new Vector3(length, 1f);
    }

    private GameObject CreateEmptyGameObject(string name)
    {
        GameObject temp = new GameObject();
        GameObject result = Instantiate(temp);
        result.name = name;
        Destroy(temp);
        return result;
    }
}
