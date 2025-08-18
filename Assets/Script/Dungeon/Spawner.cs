using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적을 생성하는 스포너 클래스입니다.
/// 플레이어 주변에서 주기적으로 적을 생성하는 역할을 담당합니다.
/// </summary>
public class Spawner : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] private PoolManager PoolManagerPrefab;
    [HideInInspector]public PoolManager pool;

    public Transform[] spawnePoints;

    [Header("SpawnData")]
    public SpawnData[] spawnData;

    private Transform PlayerTr;

    float timer;
    int level = 0;
    int maxLevel = 2;


    
    protected  void Awake() 
    {
        pool = Instantiate(PoolManagerPrefab, transform);

        spawnePoints = GetComponentsInChildren<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        
       
        level = Mathf.FloorToInt(GameManager.instance.GetGameMode().GetGameState().gameTime/ 10.0f);
        level = Mathf.Min(level, maxLevel);
        

        if(timer > spawnData[level].spawnTime)
        {
            timer = 0;
            if(PlayerTr)
                Spawn();
            else 
                SetPlayer();
        }
    }

    /// <summary>
    /// 플레이어를 찾아 스포너의 부모로 설정합니다.
    /// </summary>
    void SetPlayer()
    {
        if(PlayerTr)
            return;

        if(GameManager.instance.GetGameMode())
        {
           PlayerTr = GameManager.instance.GetGameMode().GetCharacter().transform;
           transform.SetParent(PlayerTr);
           transform.position = Vector3.zero;
        }

    }

    /// <summary>
    /// 랜덤한 위치에 적을 생성합니다.
    /// </summary>
    void Spawn()
    {
        GameObject enemy = pool.Get(0);
        if(enemy)
        {
            enemy.transform.position = spawnePoints[Random.Range(1, spawnePoints.Length)].position;
            enemy.GetComponent<EnemyBase>().Init(spawnData[level]);
        }
    }

}


[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
    public float speed;

}