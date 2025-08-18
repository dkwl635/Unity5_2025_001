using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임의 기본 모드를 관리하는 클래스입니다.
/// 플레이어와 캐릭터를 생성하고 연결하는 역할을 담당합니다.
/// </summary>
public class GameMode : MonoBehaviour
{

    [Header("PlayerController")]
    [SerializeField] private GameObject playerControllerPrefab;

    [Header("Character")]
    [SerializeField] private GameObject characterPrefab;


    [Header("GameState")]
    [SerializeField] private GameObject gameStatePrefab;

    private PlayerController playerControllerInstance;
    
    public PlayerController GetPlayerController() { return playerControllerInstance; }

    private CharacterBase characterInstance;
    
    public CharacterBase GetCharacter() { return characterInstance; }

    private GameState gameStateInstance;

    public GameState GetGameState() { return gameStateInstance; }
    
    private void Awake() 
    {
    
    }
    private void Start()
    {
         GameManager.instance.SetGameMode(this);
        SpawnGameInfo();
    }


    /// <summary>
    /// 플레이어 컨트롤러와 캐릭터를 생성하고 연결합니다.
    /// </summary>
    private void SpawnGameInfo()
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

        if(gameStatePrefab == null)
        {
            Debug.Log("No gameStatePrefab");
        }
        else
        {
            Vector3 spawnPos = Vector3.zero;
            GameObject gameStateGO = Instantiate(gameStatePrefab, spawnPos, Quaternion.identity);
            gameStateInstance = gameStateGO.GetComponent<GameState>();
            if(gameStateInstance == null)
            {
                Debug.LogError("PlayerPrefab_GameState_NULL");
            }
        }
    }

}

