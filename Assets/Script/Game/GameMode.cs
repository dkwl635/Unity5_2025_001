using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{

    [Header("PlayerController")]
    [SerializeField] private GameObject playerControllerPrefab;

    [Header("Character")]
    [SerializeField] private GameObject characterPrefab;

    private PlayerController playerControllerInstance;
    public PlayerController GetPlayerController() { return playerControllerInstance; }

    private CharacterBase characterInstance;
    public CharacterBase GetCharacter() { return characterInstance; }
    private void Start()
    {
        GameManager.instance.SetGameMode(this);

        SpawnPlayer();
    }


    private void SpawnPlayer()
    {
        if (playerControllerPrefab == null)
        {
            Debug.Log("No playerControllerPrefab");
        }
        else
        {
            Vector3 spawnPos = Vector3.zero;
            GameObject playerGO = Instantiate(playerControllerPrefab, spawnPos, Quaternion.identity);

            playerControllerInstance = playerGO.GetComponent<PlayerController>();
            if (playerControllerInstance == null)
            {
                Debug.LogError("PlayerPrefab_PlayerController_NULL");
            }

        }

        if(characterPrefab == null)
        {
            Debug.Log("No characterPrefab");
        }
        else
        {
            Vector3 spawnPos = Vector3.zero;
            GameObject characterGO = Instantiate(characterPrefab, spawnPos, Quaternion.identity);
            characterInstance = characterGO.GetComponent<CharacterBase>();
            if(characterInstance == null)
            {
                Debug.LogError("PlayerPrefab_CharacterBase_NULL");
            }
            else
            {
                characterInstance.SetPlayerController(playerControllerInstance);
                playerControllerInstance.SetCharacter(characterInstance);
            }
        }
    }

}

