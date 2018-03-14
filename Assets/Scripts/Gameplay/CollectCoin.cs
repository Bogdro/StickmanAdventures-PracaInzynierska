using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeSelf)
        {
            if (collision.tag == "Player")
            {
                LevelManager.instance.collectedCoins.Add(gameObject);
                GameManagerScript.instance.gameStats.points++;
                GameManagerScript.instance.playerStats.points++;
                GameManagerScript.instance.NotifyObservers();
                GameManagerScript.instance.SaveStats();
                gameObject.SetActive(false);
            }
        }

    }
}
