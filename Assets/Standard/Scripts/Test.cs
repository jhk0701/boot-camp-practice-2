using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public float dir;
    public InputAction moveAction;

    void Start()
    {
        moveAction.performed += TestInput;
    }

    void TestInput(InputAction.CallbackContext value)
    {

    }
}
