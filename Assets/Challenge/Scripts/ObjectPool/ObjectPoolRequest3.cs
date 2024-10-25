using UnityEngine;
using System.Collections.Generic;

namespace Challenge
{
    public class ObjectPoolRequest3 : ObjectPool
    {
        /*
            [구현사항 3]
            오브젝트를 미리 생성하지 않고 부족할 경우 누적 100개까지 추가 생성, 
            100개가 넘어갈 경우 임시로 생성 후 반환 시 파괴
        */
        const int SIZE = 100;
        [SerializeField] int instanceSize = 0;
        Queue<GameObject> pool;
        List<GameObject> tempPool;

        protected void Awake()
        {
            pool = new Queue<GameObject>();
            tempPool = new List<GameObject>();
        }

        public override GameObject GetObject()
        {
            // [요구스펙 2] Get Object
            GameObject obj;
            if (pool.Count > 0)
            {
                obj = pool.Dequeue();
            }
            else
            {
                obj = CreateObject();
                if (instanceSize < SIZE)
                {
                    instanceSize++;
                }
                else
                {
                    tempPool.Add(obj);
                }
            }
            
            return obj;
        }

        public override void ReleaseObject(GameObject obj)
        {
            // [요구스펙 3] Release Object
            obj.SetActive(false);

            if(tempPool.Contains(obj))
            {
                tempPool.Remove(obj);
                Destroy(obj);   
            }
            else
                pool.Enqueue(obj); // 반납
        }

        public override void Debug()
        {
            UnityEngine.Debug.Log($"Use Object : instances : {instanceSize}, pool : {pool.Count}, temp : {tempPool.Count}");
        }
    }
}

