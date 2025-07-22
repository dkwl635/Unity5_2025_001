using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    void OnMove(InputValue value)
    {
        Vector2 inputVec2 = value.Get<Vector2>();

        if (inputVec2 != null)
        {
            Debug.Log(inputVec2);
            //moveDirection = new Vector3(inputVec2.x, 0, inputVec2.y);
        }
    }
}
