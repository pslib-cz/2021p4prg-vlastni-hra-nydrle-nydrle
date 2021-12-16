using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    bool rewarded = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-0.6f, 0.6f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying) {
            transform.position = transform.position + new Vector3(-GameManager.obstacleVelocity * Time.deltaTime, 0, 0);
            if (!rewarded && transform.position.x < -1) {
                GameManager.score++;
                rewarded = true;
                BirdController.imageChange = true;
            }
            if (transform.position.x < -2.5) {
                transform.position = new Vector3(0.5f, Random.Range(-0.6f, 0.6f), 0);
                rewarded = false;
            }
        }
    }
}
