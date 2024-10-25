using UnityEngine;
using System.Collections.Generic;

namespace Challenge
{
    public class ObjectPoolRequest1 : ObjectPool
    {
        /*
            [구현사항 1]
            1. 최소 50개의 오브젝트 수 보장, 
            2. 부족할 경우 누적 300개까지 추가 생성, 하나씩 만들다가 300이 넘어가면 임시를 생성하고 파괴
            3. 300개가 넘어갈 경우 임시로 생성 후 반환 시 파괴
        */

        protected List<GameObject> pool;
        private List<GameObject> temporaryPool;

        // 인덱스를 사용한 이유? : 리스트에 순차적으로 접근하기 위해서
        // 요구사항에 맞지 않는 이유?
        // 오브젝트의 반환 여부를 알 수 없음 => 이것때문에 큐를 썼는데 지금 리스트로 가야한다면?
        // 반환 여부에 대한 요소가 필요.
        // 또한 현재 반환 상황이 명확하지 않음 - 이대로는 계속 만들 것임
        protected int index = 0;

        public int PoolSize { get { return pool.Count; }}
        public int DebugIndex { get { return index; }}
        public int TempPoolSize { get { return temporaryPool.Count; }}

        protected void Awake()
        {
            temporaryPool = new List<GameObject>();
            pool = new List<GameObject>();
            for (int i = 0; i < minSize; i++)
            {
                pool.Add(CreateObject());
            }
        }


        public override GameObject GetObject()
        {
            // [요구스펙 2] Get Object
            GameObject obj;

            // 요청 받았는데 넘어가면 추가 생성 : 300개 까지
            if (index >= pool.Count)
            {
                obj = CreateObject();               
                if (pool.Count <= maxSize)
                {
                    pool.Add(obj);
                }
                else // 최대치를 넘어간 경우 임시 생성
                {
                    temporaryPool.Add(obj);
                }
            }
            else
                obj = pool[index];
            
            index++;

            return obj;
        }

        public override void ReleaseObject(GameObject obj)
        {
             // [요구스펙 3] Release Object
            if(temporaryPool.Contains(obj))
            {
                //임시 생성물 파괴 절차
                temporaryPool.Remove(obj);
                Destroy(obj);
            }
            else
                obj.SetActive(false);
        }

        public override void Debug()
        {
            UnityEngine.Debug.Log($"Use Object : {DebugIndex} : {PoolSize}, {TempPoolSize}");
        }
    }   
}