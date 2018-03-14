using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject gate;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Active", false);
        gate = GameObject.FindGameObjectWithTag("Gate");
        gate.GetComponent<Animator>().SetBool("Open", false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerClone")
        {
            gate.GetComponent<Animator>().SetBool("Open", true);
            gate.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("Active", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerClone")
        {
            animator.SetBool("Active", false);
            gate.GetComponent<Animator>().SetBool("Open", false);
            gate.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
