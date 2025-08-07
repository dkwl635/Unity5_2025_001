using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Character Reference")]
    [SerializeField] private CharacterBase characterBase;

    public CharacterBase GetCharacter() { return characterBase; }
    public void SetCharacter(CharacterBase characterBase) { this.characterBase = characterBase; }



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
