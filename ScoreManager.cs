using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector]
    public static int playerScore;
    [SerializeField]
    private Text scoreText;
	// Use this for initialization
	void Start ()
    {
        playerScore = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerScore += 1;
        scoreText.text = "SCORE :" + playerScore.ToString();
	}
}
