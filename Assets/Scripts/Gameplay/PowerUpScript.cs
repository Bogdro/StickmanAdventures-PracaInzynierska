using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {
    
    public PowerUpType type;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

            switch (type)
            {
                case PowerUpType.Left:
                    collision.GetComponent<Player>().movementObject = new MoveLeft(collision.GetComponent<Player>().movementObject);
                    LevelManager.instance.canMoveLeft = true;
                    break;
                case PowerUpType.Right:
                        collision.GetComponent<Player>().movementObject = new MoveRight(collision.GetComponent<Player>().movementObject);
                    LevelManager.instance.canMoveRight = true;
                    break;
                case PowerUpType.Up:
                        collision.GetComponent<Player>().movementObject = new Jump(collision.GetComponent<Player>().movementObject);
                    LevelManager.instance.canJump = true;
                    break;
                case PowerUpType.Teleport:
                    collision.GetComponent<Player>().movementObject = new Teleport(collision.GetComponent<Player>().movementObject);
                    LevelManager.instance.canTeleport = true;
                    break;
                case PowerUpType.Clone:
                    collision.GetComponent<Player>().movementObject = new Clone(collision.GetComponent<Player>().movementObject);
                    LevelManager.instance.canClone = true;
                    break;
                default:
                    break;
            }
            LevelManager.instance.collectedPowerUps.Add(gameObject);
            gameObject.SetActive(false);
        }

    }
}
