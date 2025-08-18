using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어의 입력을 처리하고 캐릭터에 전달하는 컨트롤러입니다.
/// Unity의 새로운 Input System을 사용하여 입력을 처리합니다.
/// </summary>
public class PlayerController : MonoBehaviour
{

    [Header("Character Reference")]
    [SerializeField] private CharacterBase characterBase;

    public CharacterBase GetCharacter() { return characterBase; }
    public void SetCharacter(CharacterBase characterBase) { this.characterBase = characterBase; }



    /// <summary>
    /// 이동 입력을 받아 캐릭터에 전달합니다.
    /// </summary>
    /// <param name="value">입력 시스템에서 받은 입력 값</param>
    void OnMove(InputValue value)
    {
        Vector2 inputVec2 = value.Get<Vector2>();

        if (inputVec2 != null)
        {
            Debug.Log(inputVec2);
            if(characterBase != null)
            {
                characterBase.OnMove(inputVec2);
            }
        }
    }
}
