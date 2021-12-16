using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D birdBody;
    SpriteRenderer birdImage;
    public Sprite[] birdImages;
    public static bool imageChange = false;
    public float forceValue = 100f;
    // Start is called before the first frame update
    void Start()
    {
        birdBody = GetComponent<Rigidbody2D>();
        birdImage = GetComponent<SpriteRenderer>();
        birdImage.sprite = birdImages[Random.Range(0, birdImages.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying && Input.GetKeyDown("space")) {
            birdBody.AddForce(Vector3.up * forceValue);
        }
        if (transform.position.y > 1.18f || transform.position.y < -1.18f) {
            GameManager.isPlaying = false;
        }
        if (imageChange) {
            birdImage.sprite = birdImages[Random.Range(0, birdImages.Length)];
            imageChange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameManager.isPlaying = false;
    }
}
