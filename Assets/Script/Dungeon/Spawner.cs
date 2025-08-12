using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Pool")]
    [SerializeField] private PoolManager PoolManagerPrefab;
    [HideInInspector]public PoolManager pool;

    public Transform[] spawnePoints;

    private Transform PlayerTr;

    float timer;
    protected  void Awake() 
    {
        pool = Instantiate(PoolManagerPrefab, transform);

        spawnePoints = GetComponentsInChildren<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    void Spawn()
    {
        GameObject enemy = pool.Get(Random.Range(0,2));
        if(enemy)
        {
            enemy.transform.position = spawnePoints[Random.Range(1, spawnePoints.Length)].position;
        }
    }

}
