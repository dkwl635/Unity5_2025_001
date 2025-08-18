using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 맵 요소들의 위치를 재조정하는 클래스입니다.
/// 플레이어가 영역을 벗어날 때 지형과 적의 위치를 재배치합니다.
/// </summary>
public class Reposition : MonoBehaviour
{
    const string AreaTag = "Area";
    const string EnemyTag = "Enemy";
    const string GroundTag = "Ground";

    const float mapSize = 20;

    Collider2D coll;

    /// <summary>
    /// 콜라이더 컴포넌트를 초기화합니다.
    /// </summary>
    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    /// <summary>
    /// 트리거 영역을 벗어날 때 오브젝트의 위치를 재조정합니다.
    /// </summary>
    /// <param name="collision">충돌한 콜라이더</param>
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
                if(coll.enabled){
                    transform.Translate(playerDir * 20 + new Vector3(UnityEngine.Random.Range(-3.0f, 3.0f), UnityEngine.Random.Range(-3.0f, 3.0f), 0));
                }
             break;
                
        }

        
    }
}
