using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject {

    public string poolItemName = string.Empty;//객체를 검색할때 사용할 이름
    public GameObject prefab = null;//오브젝트 풀에 저장할 프리팹
    public int poolCount = 20; // 초기화할때 생성할 객체의 수
    public int amountPool = 0;

    [SerializeField]
    private List<GameObject> poolList = new List<GameObject>();//생성한 객체들을 저장할 리스트

    public void Initialize(Transform parent = null)//PoolObject객체를 초기화 할때 처음 한번만 호출하고 poolCount에 지정한 수만큼 객체를 생성해서 poolList에 추가
    {
            for (int index = 0; index < poolCount; index++)
            {
                poolList.Add(CreateItem(parent));
            amountPool++;
            }
    }

    //생성된 pool의 개수 return
    public int GetnumPool()
    {
        return amountPool;
    }
    //poolCount의 개수 return
    public int GetPoolCount()
    {
        return amountPool;
    }

    //사용한 객체를 다시 오브젝트 풀에 반환할때 사용할 함수, 반환할 게임 오브젝트를 item파라미터로 전달
    //이함수 역시 parent를 지정하지않으면 기본으로 ObjectPool 게임 오브젝트의 자식으로 지정
    public void PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        poolList.Add(item);
    }
    
    //객체가 필요할때 오브젝트 풀에 요청하는 용도로 사용할 함수로 먼저 저장해둔 오브젝트가 남아있는지 확인하고
    //미리 저장해둔 리스트에서 하나를 꺼내고 이객체를 반환한다
    public GameObject PopFromPool(Transform parent = null)
    {
        if (poolList.Count == 0)
            return null;
           //  poolList.Add(CreateItem(parent));

        GameObject item = poolList[0];
        poolList.RemoveAt(0);
        return item;
    }

    //이함수는 prefab변수에 지정된 게임 오브젝트를 생성 하는 역할을합니다
    //PooledObject클래스 안의 여러곳에서 객체 생성이 필요할 때 마다 사용 합니다
    //prefab에 지정한 정보를 바탕으로 게임 오브젝트를 새로 생성하고 poolitemName에 지정한 이름을 새로 생성한 게임 오브젝트 이름으로 지정합니다
    //부모계층을 지정한뒤에, 생성한 게임 오브젝트를 비활성화 시켜서 나중에 사용할 수 있도록 준비합니다
    private GameObject CreateItem(Transform parent = null)
    {
        if (amountPool < poolCount)//poolcount만큼생성안되있으면 생성
        {
            GameObject item = Object.Instantiate(prefab) as GameObject;
            item.name = poolItemName;
            item.transform.SetParent(parent);
            item.SetActive(false);
            return item;
        }
        return null;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
