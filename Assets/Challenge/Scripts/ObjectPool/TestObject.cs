using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Invoke("Return", 1f);
    }

    [ContextMenu("Return")]
    void Return()
    {
        TestManager.Instance.objectPoolTester.ReturnObject(gameObject);
    }
}
