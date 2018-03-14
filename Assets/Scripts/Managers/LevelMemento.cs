using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMemento{
    
    public Transform checkpointPosition;
    public List<GameObject> collectedCoins;
    public List<GameObject> collectedPowerUps;
    public bool canMoveRight, canMoveLeft, canJump, canTeleport, canClone;
}
