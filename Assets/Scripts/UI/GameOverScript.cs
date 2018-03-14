using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    private void Start()
    {
        GameManagerScript.instance.SaveStats();
        GameManagerScript.instance.playerStats = new Stats();
        GameManagerScript.instance.NewLevelList();

    }
}
