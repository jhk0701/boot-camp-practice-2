using UnityEngine;

namespace Challenge
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get
            {   
                // [구현 사항 1]
                // 이때 다양한 문제 상황에 대한 대응을 포함해야 함을 생각해두세요. (미할당인 경우, 생성되지 않은 경우)
                // 미할당인 경우 : 이미 있는데 할당되지 않았다.
                // 생성되지 않은 경우 : 아예 없던 경우.

                if (instance == null)
                {
                    // 미할당인 경우 : 찾는다.
                    instance = FindObjectOfType<T>();
                    
                    // 생성되지 않은 경우 : 새로 만든다.
                    if(instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        instance = go.AddComponent<T>();
                    }
                }
                
                return instance;
            }
        }

        //[구현 사항 2]
        // Singleton<T>를 상속받는 컴포넌트를 포함한 게임오브젝트는 다른 씬으로 넘어가도 파괴되지 않게 하세요. 
        // 이때, 누군가의 자식일 때는 이에 대한 루트 컴포넌트 전체가 해당 특성이 적용되도록 하세요.
        public virtual void Awake()
        {
            // make it as dontdestroyobject
            DontDestroyOnLoad(gameObject);        
        }
    }
}

