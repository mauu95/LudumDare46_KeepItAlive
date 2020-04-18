using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGMap : MonoBehaviour {
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
    private PlayerMovement playerMovement;

    private void Start() {
        iseed = new IteratorSeed(seed);
        map = CreateEmptyGameObject("map");
        playerMovement = player.GetComponent<PlayerMovement>();
        CreateChunk(0);
    }

    private void Update() {
        int current = Mathf.FloorToInt(player.position.x / 100);
        if (current >= counter) {
            CreateChunk(++counter);
        }
    }

    private void CreateChunk(int nChunk) {
        GameObject currentChunk = CreateEmptyGameObject("Chunk" + counter.ToString());
        currentChunk.transform.position = new Vector3(nChunk * 100, 0f);
        currentChunk.transform.SetParent(map.transform);
        int greenCosiCount = (int)Mathf.Ceil(100f / (4f * playerMovement.speed));
        // generate the background
        Instantiate(background, new Vector3(nChunk * 100, 0f), Quaternion.identity, currentChunk.transform);

        //generate the green cosi
        for (int i = 0; i < greenCosiCount; i++) {
            PlaceCoso(goodPickable, -50 + i * 100 / greenCosiCount, iseed.Next(10) + 1, currentChunk.transform);
        }


    }

    private void PlaceCoso(GameObject coso, float x, float y, Transform parent) {
        GameObject temp = Instantiate(coso, new Vector3(x + parent.position.x, y), Quaternion.identity, parent);
    }

    private GameObject CreateEmptyGameObject(string name) {
        GameObject temp = new GameObject();
        GameObject result = Instantiate(temp);
        result.name = name;
        Destroy(temp);
        return result;
    }
}
