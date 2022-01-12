using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static Rigidbody2D birdBody;
    SpriteRenderer birdImage;
    public Sprite[] birdImages;
    public static bool imageChange = false;
    public static float forceValue = 100f;
    public static Vector3 defaultBirdPos;
    // Start is called before the first frame update
    void Start()
    {
        defaultBirdPos = transform.position;
        birdBody = GetComponent<Rigidbody2D>();
        birdImage = GetComponent<SpriteRenderer>();
        birdImage.sprite = birdImages[Random.Range(0, birdImages.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.isPlaying || GameManager.isStarting) && Input.GetKeyDown("space"))
        {
            birdBody.AddForce(Vector3.up * forceValue);
        }
        if (transform.position.y > 1.18f || transform.position.y < -1.18f)
        {
            GameManager.isPlaying = false;
            GameManager.isGameOver = true;
        }
        if (imageChange)
        {
            birdImage.sprite = birdImages[Random.Range(0, birdImages.Length)];
            imageChange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject g = collision.gameObject;
        if (g.tag == "Obstacle")
        {
            GameManager.isPlaying = false;
            GameManager.isGameOver = true;
        }
        else if (g.tag == "SpeedUp")
        {
            GameManager.obstacleVelocity = 1f;
            GameManager.backgroundVelocity = 1f;
            g.SetActive(false);
        }
        else if (g.tag == "SpeedDown")
        {
            GameManager.obstacleVelocity = 0.45f;
            GameManager.backgroundVelocity = 0.45f;
            g.SetActive(false);
        }
        else if (g.tag == "GravityUp")
        {
            birdBody.gravityScale = 0.5f;
            g.SetActive(false);
        }
        else if (g.tag == "GravityDown")
        {
            birdBody.gravityScale = 0.15f;
            g.SetActive(false);
        }
    }
}
