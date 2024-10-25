using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public class ObjectPoolRequest2 : ObjectPool
    {
        /*
            [구현사항 2]
            1. 최소 50개의 오브젝트 수 보장, 
            2. 부족할 경우 누적 300개까지 추가 생성, 
            3. 300개가 넘어갈 경우 가장 오래전에 생성된 오브젝트를 반환 후 재사용

            결론적으로 이 요구사항의 최선은 큐로 보임.
        */

        // 리스트를 쓴다? - 사용 중인 오브젝트를 순차적으로 담을 수 있음.
        // remove가 빈자리를 순차적으로 메꿈
        // insert는 이후 자리를 밀어냄
        // best는 역시 큐 - 가장 오래된 것이 무엇인지 알 수 있으므로
        // public List<GameObject> usingObjects;
        Queue<GameObject> pool;

        protected void Awake()
        {
            pool = new Queue<GameObject>();
            
            for (int i = 0; i < minSize; i++)
            {
                pool.Enqueue(CreateObject());
            }
        }

        public override GameObject GetObject()
        {
            // [요구스펙 2] Get Object
            GameObject obj;

            if (pool.Peek().activeInHierarchy) // 사용 중
            {
                // 요청 받았는데 넘어가면 추가 생성 : 300개 까지
                // 가장 오래전에 생성된 오브젝트 반환
                if (pool.Count < maxSize)
                {
                    obj = CreateObject(); // 생성 후 사용
                    pool.Enqueue(obj); // 바로 뒷자리로 삽입
                }
                else
                {
                    ReleaseObject(pool.Peek()); // 가장 오래전에 사용한 오브젝트 강제 반환
                    obj = pool.Dequeue();
                    pool.Enqueue(obj);
                }
            }
            else
            {
                obj = pool.Dequeue();
                pool.Enqueue(obj);
            }

            return obj;
        }

        public override void ReleaseObject(GameObject obj)
        {
            // [요구스펙 3] Release Object
            obj.SetActive(false);
        }

        public override void Debug()
        {
            UnityEngine.Debug.Log($"Use Object : {pool.Count}");
        }
    }   
}