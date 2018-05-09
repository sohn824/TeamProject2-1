using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trap")
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine("DestroyBullet");
    }

    void Update()
    {
        transform.position += Vector3.right * m_speed * Time.deltaTime;
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
