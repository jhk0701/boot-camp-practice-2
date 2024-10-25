using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public class ObjectPoolTester : MonoBehaviour
    {
        [SerializeField] ObjectPool objectPool1;
        [SerializeField] float delayTime = 0.2f;

        [SerializeField] int repeatCount = 305;
        void Start()
        {
            TestManager.Instance.objectPoolTester = this;

            for (int i = 0; i < repeatCount; i++)
            {
                UseObject();
            }
        }

        // test case 1
        void UseObject()
        {
            objectPool1.Debug();
            objectPool1.GetObject().SetActive(true);
        }

        public void ReturnObject(GameObject obj)
        {
            Debug.Log("Return Object");
            objectPool1.ReleaseObject(obj);
        }
    }
}