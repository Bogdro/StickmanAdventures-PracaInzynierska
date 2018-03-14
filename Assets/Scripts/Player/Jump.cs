using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IPlayerMovement {
    private IPlayerMovement previousPlayerMovement;

    public Jump(IPlayerMovement previousMovement)
    {
        previousPlayerMovement = previousMovement;
    }

    public void UpdateMovement(Player player)
    {
        previousPlayerMovement.UpdateMovement(player);
        if (Input.GetKey(KeyCode.Space) && !player.stunned|| Input.GetKey(KeyCode.JoystickButton0) && !player.stunned)
        {
            if (player.IsGrounded())
            {
                player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
            }
        }
    }
}
