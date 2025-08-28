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
        Init();
    }

    void Update()
    {
         switch(id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }

        //Test code
        if(Input.GetKeyDown(KeyCode.L))
        {
            LevelUp(10.0f, 10);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;
        if(id == 0)
            Batch();

    
    }

    public void Init()
    {
        switch(id)
        {
            case 0:
                speed = -150.0f;
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        if(!pool)
            return;
        
        for(int index = 0 ; index < count ; index++)
        {
            Transform bullet = null;
            if(index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = pool.Get(prefabId).transform;
                bullet.SetParent(transform);
            }
           
            //Init Position
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360.0f * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(Vector3.up * 1.5f);

           bullet.GetComponent<Bullet>().Init(damage, -1); // -1 is infinite

        }
    }

}
    
