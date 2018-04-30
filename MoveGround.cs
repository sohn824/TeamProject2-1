using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public string poolItemName = "MovingPlatform2";//오브젝트 풀에 저장된 bullet오브젝트의 이름
    public float moveSpeed = 10f;//스피드
    public float lifeTime = 3f;//수명
    public float _elapsedTime = 0f;//활성화된뒤 경과시간을 계산하기 위한 변수

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= transform.right * moveSpeed * Time.deltaTime;

        if (GetTimer() > lifeTime)
        {
            SetTimer();
            ObjectPool.Instance.PushToPool(poolItemName, gameObject);
        }
	}

    float GetTimer()
    {
        return (_elapsedTime += Time.deltaTime);
    }

    void SetTimer()
    {
        _elapsedTime = 0f;
    }
}
