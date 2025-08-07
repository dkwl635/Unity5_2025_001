using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    const string AreaTag = "Area";
    const string EnemyTag = "Enemy";
    const string GroundTag = "Ground";

    const float mapSize = 20;



    void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.GetGameMode().GetCharacter().transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.GetGameMode().GetCharacter().moveDirection;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch(transform.tag)
        {
            case GroundTag :
                if(diffX >  diffY) {
                    transform.Translate(Vector3.right * dirX * (mapSize * 2));
                }
                else if(diffX < diffY){
                    transform.Translate(Vector3.up * dirY * (mapSize * 2));
                }
                break;
            case EnemyTag:
             break;
                
        }

        
    }
}
