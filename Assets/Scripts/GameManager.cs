using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public TMP_Text scoreText;
    public static bool isStarting;
    public static bool isPlaying;
    public static bool isGameOver;
    public static float obstacleVelocity = 0.6f;
    public static float backgroundVelocity = 0.6f;

    GameObject[] startupObjects;
    GameObject[] gameOverObjects;

    GameObject[] player;
    GameObject[] obstacles;
    GameObject[] bonuses;

    void Start() {
        startupObjects = GameObject.FindGameObjectsWithTag("Startup");
        gameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");
        player = GameObject.FindGameObjectsWithTag("Player");
        obstacles = GameObject.FindGameObjectsWithTag("ObstacleContainer");
        bonuses = GameObject.FindGameObjectsWithTag("Bonuses");
        Startup();
    }

    void Update() {
        scoreText.text = "" + score;

        if (isStarting)
        {
            Time.timeScale = 0;
            foreach (GameObject g in startupObjects)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in player)
            {
                g.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1;
            foreach (GameObject g in startupObjects)
            {
                g.SetActive(false);
            }
        }

        if (isGameOver)
        {
            isPlaying = false;
            foreach(GameObject g in gameOverObjects)
            {
                g.SetActive(true);
            }
            
            
            foreach(GameObject g in player) {
                g.SetActive(false);
                g.SetActive(true);
            }
        }

        if (Input.GetKeyDown("space") && isStarting && !isPlaying)
        {
            isStarting = false;
            isPlaying = true;
        }

        if (Input.GetKeyDown("space") && isGameOver)
        {
            Startup();
        }
    }

    
    public static void Reset()
    {
        GameManager.obstacleVelocity = 0.6f;
        GameManager.backgroundVelocity = 0.6f;
        BirdController.birdBody.gravityScale = 0.25f;
    }

    void Startup()
    {
        score = 0;
        isStarting = true;
        isPlaying = false;
        isGameOver = false;
        foreach(GameObject g in startupObjects)
        {
            g.SetActive(true);
        }
        foreach(GameObject g in gameOverObjects)
        {
            g.SetActive(false);
        }
        foreach(GameObject g in player) {
            g.transform.position = BirdController.defaultBirdPos;
            BirdController.birdBody.AddForce(-Vector3.up);
        }
        foreach(GameObject g in obstacles) {
            g.transform.position = ObstacleController.defaultObstaclePos;
        }
        foreach(GameObject g in bonuses) {
            g.transform.position = BonusController.defaultBonusPos;
        }
        GameManager.Reset();
    }
}
