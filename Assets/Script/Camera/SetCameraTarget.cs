using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetCameraTarget : MonoBehaviour
{
    [SerializeField]public CinemachineVirtualCamera Camera;

    void FixedUpdate()
    {
        if(Camera && Camera.Follow)
            return;
        
        Transform target = GameManager.instance.GetGameMode().GetCharacter().transform;

        if(Camera)
        {
            Camera.Follow = target;
        }
    }
}
