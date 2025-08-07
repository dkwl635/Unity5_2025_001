using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SpriteController : MonoBehaviour
{

    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField] public Vector2 moveDirection;

    const string Key_Speed = "Speed";

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
    void LateUpdate()
    {
        animator.SetFloat(Key_Speed , moveDirection.magnitude);

        if(moveDirection.x != 0)
        {
            sprite.flipX = moveDirection.x > 0 ? false : true;
        }
    }
}
