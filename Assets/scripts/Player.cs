using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    float speed = 10;
    float screenHalfWithInWorldUnits;
    
    void Start() {
        float halfPlayerWidth = transform.localScale.x/2;
        screenHalfWithInWorldUnits = (Camera.main.aspect * Camera.main.orthographicSize) + halfPlayerWidth;

    }

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWithInWorldUnits) {
            transform.position = new Vector2 (screenHalfWithInWorldUnits, transform.position.y);
        } 
        else if (transform.position.x > screenHalfWithInWorldUnits) {
            transform.position = new Vector2 (-screenHalfWithInWorldUnits, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "fallingBlock") {
            Destroy (gameObject);
        }
    }
}
