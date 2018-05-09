using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public int hpMax = 10;
    [HideInInspector]
    public int hp;
    private bool isDamage = false;
    private Rigidbody2D myRigid;
    private SpriteRenderer mySprite;
    private CapsuleCollider2D myCollider;
    float elapsed;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletTf;
    private bool grounded = false;
    private int jumpCount = 2;
    // Use this for initialization
    void Start()
    {
        myRigid = gameObject.GetComponent<Rigidbody2D>();
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        myCollider = gameObject.GetComponent <CapsuleCollider2D>();
        elapsed = Time.time;
        hp = hpMax;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trap")
        {
            StartCoroutine("PlayerDamage");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpCount = 2; //땅에 닿으면 잔여 점프횟수 초기화
        }
    }
    // Update is called once per frame
    void Update ()
    {
        KeyProcess();
        if (isDamage)
        {
            if (Time.time - elapsed >= 0.15f)
            {
                mySprite.enabled = !mySprite.enabled;
                elapsed = Time.time;
            }
        }
        else
        {
            if (mySprite.enabled == false)
                mySprite.enabled = true;
        }
        if(gameObject.transform.position.x < -1.0)
        {
            gameObject.transform.position = new Vector3(1.2f, transform.position.y, 0);
        }
    }

    void FixedUpdate()
    { 
    }

    void KeyProcess()
    {
        if(grounded)
        {
            if(jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    myRigid.AddForce(Vector2.up * 6, ForceMode2D.Impulse);  //위쪽으로 힘을 줘서 점프효과를 줬다
                    jumpCount--;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(bullet, bulletTf.position, Quaternion.identity);
        }
        
    }
    IEnumerator PlayerDamage()
    {
        hp -= 1;
        isDamage = true;
        yield return new WaitForSeconds(1.5f);
        isDamage = false;
        mySprite.enabled = true;
    }



}


