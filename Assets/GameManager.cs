using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public static bool isStarting = true;
    public static bool isPlaying = false;
    public static float obstacleVelocity = 0.6f;
    public static float backgroundVelocity = 0.6f;
    public static int score = 0;
    GameObject[] pauseObjects;

    void Start() {
        pauseObjects = GameObject.FindGameObjectsWithTag("HideOnPause");
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    void Update() {
        obstacleVelocity += 0.005f * Time.deltaTime;
        backgroundVelocity += 0.005f * Time.deltaTime;
        scoreText.text = "" + score;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                foreach(GameObject g in pauseObjects)
                {
                    g.SetActive(true);
                }
            }
            else
            {
                Time.timeScale = 1;
                foreach(GameObject g in pauseObjects)
                {
                    g.SetActive(false);
                }
            }
        }
        if (isStarting) {
            Time.timeScale = 0;
            foreach(GameObject g in pauseObjects)
            {
                g.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1;
            foreach(GameObject g in pauseObjects)
            {
                g.SetActive(false);
            }
        }

        if (Input.GetKeyDown("space") && isStarting && !isPlaying) {
            isStarting = false;
            isPlaying = true;
        }
    }
}
