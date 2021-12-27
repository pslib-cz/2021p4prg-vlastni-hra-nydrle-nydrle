using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BonusController : MonoBehaviour
{
    public GameObject[] BonusObjects;
    private int CurrentBonusIndex;
    private GameObject CurrentBonus;
    public static Vector3 defaultBonusPos;

    // Start is called before the first frame update
    void Start()
    {
        defaultBonusPos = transform.position;
        var speedUp = GameObject.FindGameObjectsWithTag("SpeedUp");
        var speedDown = GameObject.FindGameObjectsWithTag("SpeedDown");
        var gravityUp = GameObject.FindGameObjectsWithTag("GravityUp");
        var gravityDown = GameObject.FindGameObjectsWithTag("GravityDown");
        BonusObjects = speedUp.Concat(speedDown).Concat(gravityUp).Concat(gravityDown).ToArray();
        BonusInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying)
        {
            transform.position = transform.position + new Vector3(-GameManager.obstacleVelocity * Time.deltaTime, 0, 0); 
            if (transform.position.x < -4)
            {
                transform.position = new Vector3(4f, 0, 0);
                BonusInit();
            }
        }
    }

    private void BonusInit()
    {
        CurrentBonusIndex = Random.Range(0, BonusObjects.Length);
        CurrentBonus = BonusObjects[CurrentBonusIndex];
        foreach (var obj in BonusObjects)
        {
            if (obj == CurrentBonus)
            {
                obj.SetActive(true);
                obj.transform.position = new Vector3(4f, Random.Range(-0.8f, 0.8f), 0);
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }
}
