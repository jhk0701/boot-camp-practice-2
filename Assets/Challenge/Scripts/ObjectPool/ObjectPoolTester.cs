using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public class ObjectPoolTester : MonoBehaviour
    {
        [SerializeField] ObjectPool objectPool;
        [SerializeField] float delayTime = 0.2f;

        [SerializeField] int repeatCount = 305;
        void Start()
        {
            TestManager.Instance.objectPoolTester = this;
        }

        [ContextMenu("Test")]
        void Test()
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
    }
}