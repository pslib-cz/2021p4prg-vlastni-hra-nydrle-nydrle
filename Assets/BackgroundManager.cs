using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying) {
            gameObject.transform.position = transform.position + new Vector3(-GameManager.backgroundVelocity * Time.deltaTime, 0, 0);
            if (transform.position.x < -3) {
                transform.position = new Vector3(3, 0, 0);
            }

        }
    }
}
