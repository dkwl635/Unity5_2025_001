using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{

    [Header("PlayerController")]
    [SerializeField] private GameObject playerControllerPrefab;

    private PlayerController playerControllerInstance;
    public PlayerController GetPlayerController() { return playerControllerInstance; }

    private void Start()
    {
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
    }

}

