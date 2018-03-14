using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour ,IPlayerMovement
{
    private IPlayerMovement previousPlayerMovement;

    public Clone(IPlayerMovement previousMovement)
    {
        previousPlayerMovement = previousMovement;
    }

    public void UpdateMovement(Player player)
    {
        if (player == null)
        {
            return;
        }

        previousPlayerMovement.UpdateMovement(player);

        if (Input.GetKeyDown(KeyCode.J) && !player.cloned && !player.IamClone || Input.GetKeyDown(KeyCode.JoystickButton2) && !player.cloned && !player.IamClone)
        {
            Instantiate(player.playerClone, player.transform.position, player.transform.rotation);
            player.GetComponent<CommandManager>().enabled = true;
            player.cloned = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && player.cloned && !player.IamClone || Input.GetKeyDown(KeyCode.JoystickButton1) && player.cloned && !player.IamClone)
        {
            Destroy(GameObject.FindGameObjectWithTag("PlayerClone"));
            player.GetComponent<CommandManager>().enabled = false;
            player.cloned = false;
            player.Indicator.SetActive(false);
        }
    }
}
