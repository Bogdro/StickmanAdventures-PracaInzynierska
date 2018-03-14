using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (LevelManager.instance.levelNumber >= GameManagerScript.instance.playerStats.finishedLevels)
            {
                GameManagerScript.instance.playerStats.finishedLevels = LevelManager.instance.levelNumber;
            }
            StartCoroutine(LevelManager.instance.LoadLevel());
        }
    }
}
