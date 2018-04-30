using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{

    public List<PooledObject> objectPool = new List<PooledObject>();

    void Awake()
    {
        for (int index = 0; index < objectPool.Count; index++)
        {
            objectPool[index].Initialize(transform);
        }
    }

    //itemName:반환할 객체의 pool 오브젝트 이름, item: 반환할 객체- 게임 오브젝트, parent: 부모 계층 관계를 설정할 정보
    public bool PushToPool(string itemName, GameObject item, Transform parent = null)
    {
        PooledObject pool = GetPoolItem(itemName);//itemName파라미터에 전달된 이름과 동일한 pool을 찾는다

        if (pool == null)//pool검색에 실패하면 객체반환 실패
            return false;

        pool.PushToPool(item, parent == null ? transform : parent);//pool검색 성공시 PushToPool 함수를 호출하여 객체를 poolList리스트에 저장후 true 반환

        return true;
    }

    public GameObject PopFromPool(string itemName, Transform parent = null)//코루틴waitforsecons로 띄엄띄엄나오게하기
    {
        PooledObject pool = GetPoolItem(itemName);//itemName파라미터에 전달된 이름과 같은 pool을찾음
                                                 
        if (pool == null) 
        return null; //없으면 null return

        return pool.PopFromPool(parent);//있으면 객체 생성
    }

    //전달된 itemName파라미터와 같은 이름을 가진 오브젝트풀을 검색 검색에 성공하면 그결과를 리턴
    //실패하면 null을 리턴
    PooledObject GetPoolItem(string itemName)
    {
        for (int index = 0; index < objectPool.Count; index++)
        {
            if (objectPool[index].poolItemName.Equals(itemName))//objectPool에서 itemName과같은 이름의PoolItemName을 찾는다
                return objectPool[index];//있다면 object를 return
        }

        print("There is no matched pool list.");

        return null;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
