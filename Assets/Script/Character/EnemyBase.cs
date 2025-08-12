using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyBase : MonoBehaviour
{
    [Header("Movement Settings")]  
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] public Vector2 moveDirection;
    [SerializeField] private bool isLive = true;
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

    public virtual void OnMove(Vector2 inputVec2)
    {
        moveDirection = inputVec2;
    }

    private void FixedUpdate()
    {
        FindTarget();
        Movement();
    }

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
        }
    }
    void FindTarget()
    {
       

        if(target)
        {
            moveDirection = target.position - this.transform.position;
            moveDirection = moveDirection.normalized;
        }
    }
}
