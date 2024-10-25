using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public abstract class ObjectPool : MonoBehaviour
    {
        [SerializeField] GameObject prefab;

        protected const int minSize = 50;
        protected const int maxSize = 300;
        
        protected GameObject CreateObject()
        {
            // [요구스펙 1] Create Object
            GameObject go = Instantiate(prefab, transform);;
            go.SetActive(false);

            return go;
        }

        // [요구스펙 2] Get Object
        public abstract GameObject GetObject();

        // [요구스펙 3] Release Object
        public abstract void ReleaseObject(GameObject obj);

        public abstract void Debug();
    }
}