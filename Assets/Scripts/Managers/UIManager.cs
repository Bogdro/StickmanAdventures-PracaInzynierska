using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, livesText;
    public Image canMoveRightIcon, canMoveLeftIcon, canJumpIcon, canTeleportIcon, canCloneIcon;

    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        livesText = GameObject.FindGameObjectWithTag("LivesText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = "Score : " + GameManagerScript.instance.playerStats.points;

        livesText.text = "Lives : " + GameManagerScript.instance.playerStats.lives;
       
        if (FindObjectOfType<LevelManager>() != null)
        {
            if (LevelManager.instance.canMoveLeft) canMoveLeftIcon.gameObject.SetActive(true);
            else { canMoveLeftIcon.gameObject.SetActive(false); }
            if (LevelManager.instance.canMoveRight) canMoveRightIcon.gameObject.SetActive(true);
            else { canMoveRightIcon.gameObject.SetActive(false); }
            if (LevelManager.instance.canJump) canJumpIcon.gameObject.SetActive(true);
            else { canJumpIcon.gameObject.SetActive(false); }
            if (LevelManager.instance.canTeleport) canTeleportIcon.gameObject.SetActive(true);
            else { canTeleportIcon.gameObject.SetActive(false); }
            if (LevelManager.instance.canClone) canCloneIcon.gameObject.SetActive(true);
            else { canCloneIcon.gameObject.SetActive(false); }


        }
    }
}
