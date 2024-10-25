using UnityEngine;
using UnityEngine.Pool;

namespace Challenge
{
    public class ObjectPoolRequest4 : MonoBehaviour
    {
        /*
            [구현사항 3] ObjectPool로 구현
            오브젝트를 미리 생성하지 않고 부족할 경우 누적 100개까지 추가 생성, 
            100개가 넘어갈 경우 임시로 생성 후 반환 시 파괴
        */
        [SerializeField] GameObject prefab;
        public ObjectPool<GameObject> pool;
        const int SIZE = 100;
        bool collectionCheck = true;

        void Start()
        {
            pool = new ObjectPool<GameObject>(Create, OnGet, OnRelease, OnPoolDestroy, collectionCheck, 0, SIZE);    
        }

        GameObject Create()
        {
            return Instantiate(prefab, transform);
        }

        void OnGet(GameObject obj)
        {   
            // Pool에서 꺼낼 때 호출.
            obj.SetActive(true);
        }

        void OnRelease(GameObject obj)
        {
            // Pool에 반납시 호출
            obj.SetActive(false);
        }

        void OnPoolDestroy(GameObject obj)
        {
            Destroy(obj);
        }

    }
}