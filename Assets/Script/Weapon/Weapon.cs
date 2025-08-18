using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    
    public PoolManager pool;

    void Start()
    {
        pool = ((DungeonGameMode)GameManager.instance.GetGameMode()).pool;
    }

    void Update()
    {

    }

    public void Init()
    {
        switch(id)
        {
            case 0:
                speed = -150.0f;
                
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        for(int index = 0 ; index < count ; index++)
        {
           Transform bullet = pool.Get(prefabId).transform;
           bullet.SetParent(transform);
           bullet.GetComponent<Bullet>().Init(damage, -1);
        }
    }

}
    
