using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Cinemachine 카메라의 타겟을 설정하는 클래스입니다.
/// 플레이어 캐릭터를 카메라의 추적 대상으로 설정합니다.
/// </summary>
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
