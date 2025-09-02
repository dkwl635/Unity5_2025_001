using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 캐릭터의 스프라이트 애니메이션과 방향을 제어하는 클래스입니다.
/// 이동 방향에 따라 스프라이트를 좌우 반전시키고 애니메이션 속도를 조절합니다.
/// </summary>
[RequireComponent(typeof(Animator))]
public class SpriteController : MonoBehaviour
{

    public SpriteRenderer sprite;
    public Animator animator;
    [SerializeField] public Vector2 moveDirection;

    const string Key_Speed = "Speed";

    public event Action OnDieEvent;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// 애니메이션과 스프라이트 방향을 업데이트합니다.
    /// </summary>
    void LateUpdate()
    {
        animator.SetFloat(Key_Speed , moveDirection.magnitude);

        if(moveDirection.x != 0)
        {
            sprite.flipX = moveDirection.x > 0 ? false : true;
        }
    }

    public void DieEvent()
    {
        OnDieEvent?.Invoke();
    }
}
