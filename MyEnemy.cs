using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField]
    private float m_speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
        Invoke("DestroySelf", 5f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Vector3.left * m_speed * Time.deltaTime;
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
