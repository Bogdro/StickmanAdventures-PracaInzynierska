using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public IPlayerMovement movementObject;

    public GameObject Indicator;

    public bool isAlive;

    public float moveSpeed;
    public float jumpForce;

    public Rigidbody2D rb;  
    public Transform GroundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public Animator anim;

    public bool drawGizmos;

    public GameObject aimRotation;
    public GameObject aimPosition;
    public bool slowMotion;

    public bool cloned;
    public GameObject playerClone;
    public bool IamClone;

    public bool stunned;

    void Start ()
    {
        Indicator.SetActive(false);
        anim = GetComponent<Animator>();
        anim.SetBool("Grounded", false);
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
        slowMotion = false;
        aimRotation.SetActive(false);
    }

    public void Update()
    {
        HandleAnimation();
    }
    public void FixedUpdate()
    {
        if (!cloned) UpdatePlayer();
        if (stunned) StartCoroutine(WaitForStun());
    }

    public IEnumerator WaitForStun()
    {
        yield return new WaitForSeconds(1);
        stunned = false;
    }

    public void UpdatePlayer ()
    {
        movementObject.UpdateMovement(this);
        
	}

    private void HandleAnimation()
    {
        if (Mathf.Abs(rb.velocity.x) > 0)
        {
            anim.SetFloat("Speed", 1.0f);
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }

        if (IsGrounded())
        {
            anim.SetBool("Grounded", true);
        }
        else
        {
            anim.SetBool("Grounded", false);
        }

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1,1);
        }
        else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1,1);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheckPoint.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawSphere(GroundCheckPoint.position, groundCheckRadius);
        }
        }

    public void SwitchDirection(int direction)
    {
        transform.localScale = new Vector3(direction, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 1;
        slowMotion = false;
        aimRotation.SetActive(false);
    }
}
