using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    CharacterBase player;

    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    
    public PoolManager pool;

    float timer;

    void Awake()
    {
        player = GetComponentInParent<CharacterBase>();
    }
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
            case 1:
                timer += Time.deltaTime;
                if(timer > speed)
                {
                    timer = 0;
                    Fire();
                }
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
            case 1:
                speed = 0.3f;
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

            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); // -1 is infinite

        }
    }

    void Fire()
    {
        if(!player.scanner.nearestTarget)
            return;


        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;

        Transform bullet = pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, count, dir); // -1 is infinitebu


    }

}
    
