using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터의 기본 기능을 제공하는 추상 클래스입니다.
/// 플레이어와 적 캐릭터 모두가 상속받아 사용할 수 있는 공통 기능들을 포함합니다.
/// 
/// 주요 기능:
/// - 기본적인 이동 시스템 (Rigidbody2D 기반)
/// - 스프라이트 컨트롤러를 통한 애니메이션 연동
/// - 플레이어 컨트롤러 참조 관리
/// - 중력 없이 2D 평면에서의 이동 처리
/// 
/// 필수 컴포넌트:
/// - Rigidbody2D: 물리 기반 이동을 위해 필요
/// - CapsuleCollider2D: 충돌 감지를 위해 필요
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterBase : MonoBehaviour
{
   

    [Header("Player Controller Reference")]
    [SerializeField] private PlayerController playerController;

    public PlayerController GetPlayerController() { return playerController; }
    public void SetPlayerController(PlayerController playerController) { this.playerController = playerController; }


    [Header("Movement Settings")]  
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] public Vector2 moveDirection;

    SpriteController spriteController;

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
        HandleMovement();
    }

    /// <summary>
    /// 실제 이동 로직을 처리합니다.
    /// </summary>
    private void HandleMovement()
    {
        if (moveDirection.magnitude > 0.1f)
        {
            // Rigidbody를 이용한 이동 (중력 없이)
            Vector2 targetVelocity = moveDirection * moveSpeed;
            rb.velocity = targetVelocity;
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


}
