using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임의 전역 상태를 관리하는 싱글톤 매니저입니다.
/// 현재 게임 모드를 관리하고 다른 시스템에서 접근할 수 있도록 합니다.
/// </summary>
public class GameManager : MonoBehaviour
{   
    public static GameManager instance;
    

    [SerializeField] private GameMode curGameMode;
    
    public GameMode GetGameMode(){return curGameMode;}
    public void SetGameMode(GameMode gameMode){curGameMode = gameMode;}

    void Awake()
    {
        instance = this;
    }

    
}
