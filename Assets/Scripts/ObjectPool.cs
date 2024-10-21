using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Arrow,
    Monster
}

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();
    private Dictionary<string, int> poolIndexes = new Dictionary<string, int>();
    private int poolIndex = 0;
    public int poolSize = 300;

    void Start()
    {
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(prefab, transform);
            instance.SetActive(false);

            pool.Add(instance);
        }

        poolIndex = 0;
    }

    #region *** Q2 요구사항 2 ***
    #endregion

    #region *** Q2 요구사항 1 ***
    /*
    public GameObject Get()
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        GameObject instance = pool[poolIndex];
        instance.SetActive(true);

        poolIndex++;

        if (poolIndex >= poolSize)
            poolIndex = 0;

        return instance;
    }

    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
    }
    */
    #endregion
    
}
