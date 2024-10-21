using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    ObjectPoolRequest1 objectPoolRequest1;

    void Start()
    {
        objectPoolRequest1 = GetComponent<ObjectPoolRequest1>();
    }

    public void GetObject()
    {

    }
}
