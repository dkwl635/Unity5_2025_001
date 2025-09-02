using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [Header("# GameControl")]
    public  float gameTime = 0.0f;
    public  float maxGameTime = 2.0f * 10.0f ;
    
    [Header("# PlayerInfo")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {10, 30, 60, 100, 150, 210, 280, 360, 450, 550};
    
    void Update(){
        
        gameTime  += Time.deltaTime;
        
        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;
        if(exp >= nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
}
