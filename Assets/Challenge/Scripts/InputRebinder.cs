using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    InputAction action;
    [SerializeField] InputActionAsset actionAsset;

    void OnEnable()
    {
        action = actionAsset.FindAction("Space");

        action.Enable();
    }

    [ContextMenu("Rebind")]
    void RebindSpaceToEscape()
    {

    }

    void TestSpace(InputAction.CallbackContext value)
    {
        Debug.Log(value.ReadValue<bool>());
    }
}
