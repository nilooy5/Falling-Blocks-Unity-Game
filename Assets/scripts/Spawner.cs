using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject fallingBlockPrefab;
    float secondsBetweenSpawn = 0.5f;
    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;
    float blockHeight;
    public Vector2 spawnSizeMinMax;
    float maxSpawnAngle = 15f;
    // Start is called before the first frame update
    void Start() {
        blockHeight = transform.localScale.y;
        screenHalfSizeWorldUnits = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + secondsBetweenSpawn;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

            Vector2 spawnPosition = new Vector2 (Random.Range(-1f,1f),1) * (screenHalfSizeWorldUnits + new Vector2(0, blockHeight));

            Vector3 randomRotationAngle = Vector3.forward * Random.Range(maxSpawnAngle, -maxSpawnAngle);

            GameObject newBlock = (GameObject) Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(randomRotationAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
