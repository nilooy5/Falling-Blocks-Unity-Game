using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject fallingBlockPrefab;
    float secondsBetweenSpawn = 1;
    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;
    float halfSpawnHeight;
    // Start is called before the first frame update
    void Start() {
        halfSpawnHeight = transform.localScale.y/2;
        screenHalfSizeWorldUnits = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
    
    }

    // Update is called once per frame
    void Update() {
        if(Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + secondsBetweenSpawn;

            Vector2 spawnPosition = new Vector2 (Random.Range(-1f,1f),1) * (screenHalfSizeWorldUnits + new Vector2(0, halfSpawnHeight));
            Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
