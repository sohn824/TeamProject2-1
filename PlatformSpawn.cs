using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{

    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject spikeBox;
    [SerializeField]
    private GameObject enemy;


    void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, 4f);
        InvokeRepeating("SpawnBox", 0.5f, 2f);
    }


    void SpawnCoin()
    {
       
        float randomY = Random.Range(1f, 4f);
        GameObject newCoin;
        newCoin = Instantiate(coin, new Vector3(23.9f, randomY, 0f), Quaternion.identity) as GameObject;
        
    }

    void SpawnBox()
    {
        int rand = Random.Range(0, 100);
        float randomY = Random.Range(1f, 4f);
        if (rand < 30)
        {
            GameObject newBox;
            newBox = Instantiate(spikeBox, new Vector3(23.9f, randomY, 0f), Quaternion.identity) as GameObject;
        }
        else if(rand < 100)
        {
            GameObject newEnemy;
            newEnemy = Instantiate(enemy, new Vector3(23.9f, randomY, 0f), Quaternion.identity) as GameObject;
        }
    }
}
