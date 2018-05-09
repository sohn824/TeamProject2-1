using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{
    private bool isGameOver = false;
    [SerializeField]
    private Image gameOver;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isGameOver = true;
            gameOver.gameObject.SetActive(true);
        }
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            isGameOver = false;
            gameOver.gameObject.SetActive(false);
            UnityEngine.SceneManagement.SceneManager.LoadScene("00");
        }
    }
}
