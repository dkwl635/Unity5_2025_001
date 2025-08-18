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

    private Transform PlayerTr;

    float timer;
    
    /// <summary>
    /// 풀 매니저를 생성하고 스폰 포인트를 초기화합니다.
    /// </summary>
    protected  void Awake() 
    {
        pool = Instantiate(PoolManagerPrefab, transform);

        spawnePoints = GetComponentsInChildren<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 주기적으로 적을 생성하거나 플레이어를 설정합니다.
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.2f)
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
        GameObject enemy = pool.Get(Random.Range(0,2));
        if(enemy)
        {
            enemy.transform.position = spawnePoints[Random.Range(1, spawnePoints.Length)].position;
        }
    }

}
