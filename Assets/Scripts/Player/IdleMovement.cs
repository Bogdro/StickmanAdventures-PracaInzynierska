using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMovement : IPlayerMovement
{
    public void UpdateMovement(Player player)
    {
        if (player == null)
        {
            return;
        }
      
            if (!Input.GetKey(KeyCode.D) && !player.stunned || !Input.GetKey(KeyCode.A) && !player.stunned)
            {
                player.rb.velocity = new Vector2(0, player.rb.velocity.y);
            }
        
    }
}
