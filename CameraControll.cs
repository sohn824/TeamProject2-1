using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject chaseObject;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    
    Vector3 cameraPosition;

    private void Start()
    {
        offsetX = 0f;
        offsetY = 25f;
        offsetZ = -35f;
    }

    private void LateUpdate()
    {
        cameraPosition.x = chaseObject.transform.position.x;
        cameraPosition.y = chaseObject.transform.position.y;
        cameraPosition.z = chaseObject.transform.position.z;

        transform.position = cameraPosition;
    }
}
