using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : IPlayerMovement
{
    private IPlayerMovement previousPlayerMovement;

    public Teleport(IPlayerMovement previousMovement)
    {
        previousPlayerMovement = previousMovement;
    }
    public void UpdateMovement(Player player)
    {
        previousPlayerMovement.UpdateMovement(player);
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            Time.timeScale = 0.3f;
            player.slowMotion = true;
            player.aimRotation.SetActive(true);
        }
       
        if (Input.GetKey(KeyCode.W) && player.slowMotion == true)
        {
            if (player.aimRotation.transform.rotation.eulerAngles.z < 180) player.aimRotation.transform.Rotate(new Vector3(0f, 0f, 1));
        }
        if (Input.GetKey(KeyCode.S) && player.slowMotion == true)
        {
            if (player.aimRotation.transform.rotation.z > 0.001) player.aimRotation.transform.Rotate(new Vector3(0f, 0f, -1));
        }
        if (Input.GetKey(KeyCode.L) && Time.timeScale < 1 || Input.GetKey(KeyCode.JoystickButton4) && Time.timeScale < 1)
        {
            player.transform.position = new Vector2(player.aimPosition.transform.position.x, player.aimPosition.transform.position.y);
            Time.timeScale = 1;
            player.slowMotion = false;
            player.aimRotation.SetActive(false);
        }
    }
}
