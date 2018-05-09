using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float m_speed = 0.2f;
    Material m_material;

    // Use this for initialization
    void Start ()
    {
        m_material = GetComponent<MeshRenderer>().material;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //m_material.mainTextureOffset = new Vector2(0, m_material.mainTextureOffset.y + m_speed * Time.deltaTime);
        m_material.mainTextureOffset = new Vector2(m_material.mainTextureOffset.x + m_speed * Time.deltaTime , 0);

    }
}
