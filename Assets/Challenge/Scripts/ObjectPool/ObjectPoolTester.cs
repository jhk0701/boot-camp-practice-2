using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public class ObjectPoolTester : MonoBehaviour
    {
        [SerializeField] float delayTime = 0.2f;
        [SerializeField] int repeatCount = 305;
        
        [Header("Request 1~3")]
        [SerializeField] ObjectPool objectPool;

        [Header("Request 4")]
        [SerializeField] ObjectPoolRequest4 unityPool;


        void Start()
        {
            TestManager.Instance.objectPoolTester = this;
        }

        [ContextMenu("Test1")]
        void Test1()
        {
            for (int i = 0; i < repeatCount; i++)
            {
                UseObject();
            }
        }

        // test case
        void UseObject()
        {
            objectPool.Debug();
            objectPool.GetObject().SetActive(true);
        }

        public void ReturnObject(GameObject obj)
        {
            Debug.Log("Return Object");
            objectPool.Debug();
            objectPool.ReleaseObject(obj);
        }


        
        List<GameObject> list = new List<GameObject>();
        [ContextMenu("TestGet")]
        void TestGet()
        {
            for (int i = 0; i < repeatCount; i++)
            {
                list.Add(unityPool.pool.Get());
                Debug.Log("Get from unity pool : " + list.Count);
            }
        }

        
        [ContextMenu("TestRelease")]
        void TestRelease()
        {
            for (int i = 0; i < list.Count; i++)
            {
                unityPool.pool.Release(list[i]);
                Debug.Log($"Release to unity pool Active : {unityPool.pool.CountActive}, Inactive : {unityPool.pool.CountInactive}, All : {unityPool.pool.CountAll}");
            }

            list.Clear();
        }
    }
}