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
    
    /// <summary>
    /// 현재 게임 모드를 반환합니다.
    /// </summary>
    /// <returns>현재 설정된 게임 모드</returns>
    public GameMode GetGameMode(){return curGameMode;}
    
    /// <summary>
    /// 게임 모드를 설정합니다.
    /// </summary>
    /// <param name="gameMode">설정할 게임 모드</param>
    public void SetGameMode(GameMode gameMode){curGameMode = gameMode;}

    /// <summary>
    /// 싱글톤 인스턴스를 초기화합니다.
    /// </summary>
    void Awake()
    {
        instance = this;
    }

    
}
