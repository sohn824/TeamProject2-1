using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;
    private float current = 0.0f;
    public SpriteRenderer coinSprite;

    // Use this for initialization
    void Start()
    {
        coinSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            coinSprite.enabled = false;
            StartCoroutine("ResetCoin");
        }
    }

    //void DestroySelf()
    //{
    //    Destroy(gameObject);
    //}
    IEnumerator ResetCoin()
    {
        yield return new WaitForSeconds(1.5f);
        coinSprite.enabled = true;
    }
}
