using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Player playerScript;
    [SerializeField]
    private Slider hpBar;
	// Use this for initialization
	void Start ()
    {
        playerScript = GameObject.Find("Ellen").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        hpBar.value = (float)playerScript.hp / (float)playerScript.hpMax;
	}
}
