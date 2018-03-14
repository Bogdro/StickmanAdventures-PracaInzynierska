using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : Command {

    public MovementCommand(Player player) : base(player) {
    }

    public override void Execute() {
        reciever.UpdatePlayer();
    }
}
