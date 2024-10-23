using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        private List<GameObject> pool;
        private int index = 0;
        private const int minSize = 50;
        private const int maxSize = 300;

        void Awake()
        {
            pool = new List<GameObject>();
            for (int i = 0; i < minSize; i++)
            {
                pool.Add(CreateObject());
            }
        }

        /*
            [구현사항 1]
            1. 최소 50개의 오브젝트 수 보장, 
            1. 부족할 경우 누적 300개까지 추가 생성, 
            300개가 넘어갈 경우 임시로 생성 후 반환 시 파괴
        */

        private GameObject CreateObject()
        {
            // [요구스펙 1] Create Object
            return Instantiate(prefab, transform);
        }

        public GameObject GetObject()
        {
            // [요구스펙 2] Get Object
            return null;
        }

        public void ReleaseObject(GameObject obj)
        {
            // [요구스펙 3] Release Object
        }
    }
}