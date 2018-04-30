using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTile : MonoBehaviour
{

    [SerializeField]
    private string TileName;
    private string TileName2;
    [SerializeField]
    private float SetTime;
    [SerializeField]
    private float CurrentTime;
    public float positionY;
    Vector3 P;
    [SerializeField]
    private GameObject Ellen;
    public int num;
    // Use this for initialization
    void Awake()
    {
        SetTime = 1.0f;//Random.Range(5.0f, 8.0f);
        CurrentTime = 0.0f;
        positionY = Random.Range(-2.0f, 2.0f);
    }

    void Start()
    {
        TileName = "MovingPlatform2";
        TileName2 = "MovingPlatform3";
        P = Ellen.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime >= SetTime)
        {
            positionY = Random.Range(Ellen.transform.position.y - 5.0f, Ellen.transform.position.y + 5.0f);
            Create(positionY);
            CurrentTime = 0f;
        }         
           
    }

    void Create(float PositionY)
    {
        num = (int)Random.Range(1.0f, 2.9f);

        switch (num)
        {
            case 1:
                GameObject Tile = ObjectPool.Instance.PopFromPool(TileName);
                Tile.transform.position = P + new Vector3(0.0f, PositionY, 0.0f);
                Tile.SetActive(true);
                break;

            case 2:
                GameObject Tile2 = ObjectPool.Instance.PopFromPool(TileName2);
                Tile2.transform.position = P + new Vector3(0.0f, PositionY, 0.0f);
                Tile2.SetActive(true);
                break;
        }
    }
}
