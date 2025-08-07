using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
