using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Arrow = 0,
    Monster
}

public class ObjectPoolRequest2 : MonoBehaviour
{
    public GameObject[] prefabs;
    
    // 요구사항에 따라 문자열로 우선 사용
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();
    private Dictionary<string, int> poolIndexes = new Dictionary<string, int>();
    public int poolSize = 300;

    void Start()
    {
       Initialize(PoolType.Arrow);
       Initialize(PoolType.Monster);
    }

    void Initialize(PoolType type)
    {
        pools.Add(type.ToString(), new List<GameObject>());

        GameObject holder = new GameObject(type.ToString());
        holder.transform.SetParent(transform);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance= Instantiate(prefabs[(int)type], holder.transform);
            pools[type.ToString()].Add(instance);
        }

        poolIndexes.Add(type.ToString(), 0);
    }

    public GameObject Get(PoolType type)
    {
        string typeName = type.ToString();

        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        GameObject instance = pools[typeName][poolIndexes[typeName]];
        instance.SetActive(true);

        poolIndexes[typeName]++;
        if(poolIndexes[typeName] >= poolSize)
            poolIndexes[typeName] = 0;
        
        return instance;
    }

    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
    }
    
}
