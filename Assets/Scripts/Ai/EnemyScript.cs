using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int direction;

    public float speed;
    public float fieldOfViewRadius;
    public float fieldOfViewOffset;

    public GameObject warnIndicator;

    public Vector2 boxSize;

    public bool FieldOfViewGizmos;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask whatToLookingFor;
    public LayerMask whatToCollideWith;

    public EnemyAbstractState state;
    public EnemyAbstractState chaseState;
    public EnemyAbstractState patrolState;
    public EnemyAbstractState attackState;

    private SpriteRenderer spriteRenderer;
    private Transform myTransform;

    private Rigidbody2D rb;
    private Rigidbody2D myRigidbody;

    public Vector2 knockback;

    void Start()
    {
        warnIndicator.SetActive(false);

        direction = 1;
        chaseState = new EnemyChaseState();
        patrolState = new EnemyPatrolState();

        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();

        state = new EnemyPatrolState();
    }

    void Update()
    {
        state.Update(this);
    }

    public Collider2D PlayerInFielOfView()
    {

        Collider2D obiekt = Physics2D.OverlapBox(transform.position + new Vector3(fieldOfViewOffset * direction, 0, 0), boxSize, 0, whatToLookingFor);
        if (obiekt != null && obiekt.tag == "Player")
        {
            return obiekt;
        }
        return null;
    }

    public void EnemyMovement()
    {
        if (!IsOnPlatform() || CollidingWithWall())
        {
            FlipEnemy(direction * -1);
        }
        else
        {
            MoveEnemy();
        }
    }

    public void MoveEnemy()
    {
        myRigidbody.velocity = new Vector2(direction * speed, myRigidbody.velocity.y);
    }

    public bool IsOnPlatform()
    {
        //Debug.DrawRay((Vector2)groundCheck.position, Vector3.down);
        if (Physics2D.Raycast((Vector2)groundCheck.position, Vector2.down, 1))
        {
            return true;
        }
        return false;
    }

    public bool CollidingWithWall()
    {
        //Debug.DrawRay(transform.position, new Vector2(direction, 0), Color.cyan);

        var obiekt = Physics2D.Raycast((Vector2)wallCheck.position, (Vector2)groundCheck.position * direction, 0.2f);

        if (obiekt.collider != null)
        {
            if (obiekt.transform.tag == "Grass" || obiekt.transform.tag == "Gate")
            {
                return true;
            }
        }
        return false;
    }

    public void FlipEnemy(int dir)
    {
        direction = dir;
        myTransform.localScale = new Vector3(direction, 1, 1);
        knockback = new Vector2(-knockback.x, knockback.y);
    }

    public void ChasePlayer(Collider2D player)
    {
        int chasingDirection = (int)Mathf.Sign(this.transform.position.x - player.transform.position.x) * -1;
        FlipEnemy(chasingDirection);
        MoveEnemy();
    }

    private void OnDrawGizmos()
    {
        if (FieldOfViewGizmos)
        {
            Gizmos.DrawCube(transform.position + new Vector3(fieldOfViewOffset * direction, 0, 0), new Vector3(boxSize.x, boxSize.y, 1));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Destroy(collision.gameObject);
            //LevelManager.instance.RespawnPlayer(LevelManager.instance.checkPointMemento);
            collision.GetComponent<Rigidbody2D>().AddForce(knockback, ForceMode2D.Impulse);
            collision.GetComponent<Player>().stunned = true;
            Debug.Log("Serwus");
        }
    }
}
