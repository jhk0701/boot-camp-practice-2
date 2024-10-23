using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public class TestObjectPool : MonoBehaviour
    {
        [SerializeField] ObjectPool objectPool;
        [SerializeField] float delayTime = 1f;
        [SerializeField] GameObject usingObject;

        void Start()
        {
            UseObject();
        }

        void UseObject()
        {
            Debug.Log("Use Object");
            
            usingObject = objectPool.GetObject();

            Invoke("ReturnObject", delayTime);
        }

        void ReturnObject()
        {
            Debug.Log("Return Object");
            objectPool.ReleaseObject(usingObject);
            usingObject = null;
        }
    }
}