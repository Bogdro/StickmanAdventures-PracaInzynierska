using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : IPlayerMovement
{
    private IPlayerMovement previousPlayerMovement;

    public MoveRight(IPlayerMovement previousMovement)
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
        if (Input.GetKey(KeyCode.D) && !player.stunned)
        {
            player.rb.velocity = new Vector2(player.moveSpeed, player.rb.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") > 0 && !player.stunned)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                player.rb.velocity = new Vector2(player.moveSpeed, player.rb.velocity.y);
            }
        }
    }
}
