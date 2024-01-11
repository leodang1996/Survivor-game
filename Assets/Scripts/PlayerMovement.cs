using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    PlayerInput input;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Vector2 moveDirection;

    [SerializeField] float moveSpeed;
    [HideInInspector] float lastHorizontalVector;
    [HideInInspector] float lastVerticalVector;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        input = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        moveDirection = input.Player.Move.ReadValue<Vector2>();
        if(moveDirection.magnitude != 0)
        {
            animator.SetBool("Move", true);
            PlayerDirection();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    void PlayerDirection()
    {
        //lấy hướng cuối cùng để tránh x = 0 sẽ flip theo default
        if(moveDirection.x != 0)
        {
            lastHorizontalVector = moveDirection.x;
        }
        if(moveDirection.y != 0)
        {
            lastVerticalVector = moveDirection.y;
        }
        //quay mặt theo hướng cuối cùng
        if (lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
