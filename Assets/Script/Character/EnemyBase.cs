using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 적 캐릭터의 기본 기능을 제공하는 클래스입니다.
/// 플레이어를 자동으로 추적하고 이동하는 AI 기능을 포함합니다.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyBase : MonoBehaviour
{
    [Header("Movement Settings")]  
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] public Vector2 moveDirection;
    [SerializeField] private bool isLive = true;
    
    public RuntimeAnimatorController[] animCon;
    public float speed;
    public float health;
    public float maxHealth;



    SpriteController spriteController;

    Transform target;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        spriteController = GetComponentInChildren<SpriteController>();
        if(spriteController == null)
        {
            Debug.LogError("SpriteController를 찾을 수 없습니다!");
        } 
    }

    private void Start()
    {
        isLive = true;
    }

    /// <summary>
    /// 이동 입력을 받아 처리하는 가상 메서드입니다.
    /// </summary>
    /// <param name="inputVec2">이동 방향 벡터</param>
    public virtual void OnMove(Vector2 inputVec2)
    {
        moveDirection = inputVec2;
    }

    private void FixedUpdate()
    {
        FindTarget();
        Movement();
    }

    /// <summary>
    /// 적의 이동 로직을 처리합니다.
    /// </summary>
    private void Movement()
    {
        if(isLive == false)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        

        if (moveDirection.magnitude > 0.1f)
        {
            // Rigidbody를 이용한 이동 (중력 없이)
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            // 입력이 없으면 멈춤
            rb.velocity = Vector2.zero;
            moveDirection = Vector2.zero;
        }

        if(spriteController)
        {
            spriteController.moveDirection = moveDirection;
        }
       
    }

    void OnEnable()
    {
         if(target == null)
        {
            target = GameManager.instance.GetGameMode().GetCharacter().transform;
            isLive = true;
            health = maxHealth;
        }
    }
    
    /// <summary>
    /// 플레이어 타겟을 찾아 이동 방향을 설정합니다.
    /// </summary>
    void FindTarget()
    {
        if(target)
        {
            moveDirection = target.position - this.transform.position;
            moveDirection = moveDirection.normalized;
        }
    }

    public void Init(SpawnData data)
    {
        spriteController.animator.runtimeAnimatorController = animCon[data.spriteType];
        moveSpeed = data.speed;
        maxHealth = data.health;
        health = maxHealth;
     
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Bullet"))
            return;
        
        health -= collision.GetComponent<Bullet>().damage;

        if(health > 0)
        {


        }
        else{
            Dead();
        }

    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
