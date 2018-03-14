using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public bool isMoving;
    public bool isMovingHorizontal;
    public bool isMovingVertical;
    public bool isDestructible;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    private Vector2 actuallTarget;

    public float moveSpeed;

    public float timeToDestroy, timeToSpawn;

    PlatformSpawner platformSpawner;
    public Animator animator;
    


    private void Start()
    {
        animator = GetComponent<Animator>();
        platformSpawner = FindObjectOfType<PlatformSpawner>();
        maxX += transform.position.x;
        maxY += transform.position.y;
        minX = transform.position.x - minX;
        minY = transform.position.y - minY;
        if (isMoving)
        {
            if (isMovingVertical && isMovingHorizontal)
            {
                actuallTarget = new Vector2(maxX, maxY);
            }
            else if (isMovingHorizontal)
            {
                actuallTarget = new Vector2(maxX, transform.position.y);
            }
            else if (isMovingVertical)
            {
                actuallTarget = new Vector2(transform.position.x, maxY);
            }
        }
        
    }
    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, actuallTarget, Time.deltaTime * moveSpeed);
            if (transform.position.y == maxY)
            {
                actuallTarget.y = minY;
            }
            if (transform.position.y == minY)
            {
                actuallTarget.y = maxY;
            }
            if (transform.position.x == maxX)
            {
                actuallTarget.x = minX;
            }
            if (transform.position.x == minX)
            {
                actuallTarget.x = maxX;
            }
        }
    }
    IEnumerator WaitForDestroy()
    {

        yield return new WaitForSeconds(timeToDestroy);
        Debug.Log("Wybuch!");
        platformSpawner.StartCoroutine(platformSpawner.WaitForSpawn(timeToSpawn,gameObject));
        gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDestructible)
        {
            animator.SetBool("destroy", true);
            StartCoroutine(WaitForDestroy());            
        }
    }

}
