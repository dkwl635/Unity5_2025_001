using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterBase : MonoBehaviour
{
   

    [Header("Player Controller Reference")]
    [SerializeField] private PlayerController playerController;

    public PlayerController GetPlayerController() { return playerController; }
    public void SetPlayerController(PlayerController playerController) { this.playerController = playerController; }


    [Header("Movement Settings")]  
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector2 moveDirection;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void Start()
    {
     
    }

    public virtual void OnMove(Vector2 inputVec2)
    {
        moveDirection = inputVec2;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

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
        }
    }


}
