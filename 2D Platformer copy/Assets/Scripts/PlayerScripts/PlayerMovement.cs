using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement vars")]
    [SerializeField]
    private float jumpForce = 3;
    [SerializeField]
    private float moveSpeed;
    private bool isGrounded;

    [Header ("Settings")]
    [SerializeField]
    private Transform groundColliderTransform;
    [SerializeField]
    private AnimationCurve Curve;
    [SerializeField]
    private LayerMask groundMask;
    [SerializeField]
    private float jumpOffset;
    public bool isShooting;
    public bool canMove;
    private int dir = 0;

    private bool jumping;
    private float horDirection;

    private Rigidbody2D rb;
    private Animator animator;
    private UIManager uIManager;
    private Shooter shooter;

    private void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        uIManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UIManager>();
        shooter = GetComponent<Shooter>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);

        if (jumping == true && canMove==true)
            Jump();

        if(Mathf.Abs(horDirection)>0.1f && canMove ==true)
            HorizontalMovement(horDirection);

    }

    private void Update()
    {
        if (rb.velocity.x>3)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
        if (rb.velocity.x <-3)
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
    }

    public void Move(float horizontalDirection, bool isJumpButtonPressed)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalDirection));
        if (isShooting == false)
        {
            if (isJumpButtonPressed)
                jumping = true;

            if (Mathf.Abs(horizontalDirection) > 0.01f)
                horDirection = horizontalDirection;
        }
    }

    private void HorizontalMovement(float horizontalDirection)
    {
        rb.AddForce(new Vector3(Curve.Evaluate(horizontalDirection) * moveSpeed, 0, 0));

        if(horizontalDirection>0 && isShooting == false)
        {
            rb.transform.rotation = Quaternion.Euler(0, 0, 0);
            dir = 1;

        }
        if (horizontalDirection < 0 && isShooting == false)
        {
            rb.transform.rotation = Quaternion.Euler(0, 180, 0);
            dir = -1;
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            jumping = false;
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void Death()
    {
        animator.SetTrigger("Death");
        rb.simulated = false;
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        uIManager.GameOver.gameObject.SetActive(true);
    }

    public void Fire1()
    {
        if (isShooting == false && canMove ==true)
        {
            isShooting = true;
            animator.SetTrigger("Attack");
            shooter.Shoot(dir);
        }
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(0.84f);
        isShooting = false;
    }
}