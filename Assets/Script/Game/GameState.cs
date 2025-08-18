using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public  float gameTime = 0.0f;
    public  float maxGameTime = 2.0f * 10.0f ;


    void Update(){
        
        gameTime  += Time.deltaTime;
        
        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

}
