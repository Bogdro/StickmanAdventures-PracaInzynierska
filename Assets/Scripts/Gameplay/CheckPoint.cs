using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private LevelManager levelManager;
    public Stats levelStats;
    private void Start()
    {
        
        levelManager = FindObjectOfType<LevelManager>();    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            levelManager.CreateMemento(transform);
        }
    }
}
