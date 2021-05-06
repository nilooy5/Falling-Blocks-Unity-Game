using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;
    void Start() {
        FindObjectOfType<Player> ().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update() {
        if (gameOver) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                SceneManager.LoadScene (0);
            }
        }
    }
    void OnGameOver() {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
