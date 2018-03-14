using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLevelFactory : MonoBehaviour {

    public abstract GameObject CreatePlatform();
    public abstract GameObject CreateMovingPlatformYP();

    //Elementy wspólne dla wszystkich poziomów

    public virtual GameObject CreateCheckpoint() { return Resources.Load("Checkpoint") as GameObject; }
    public virtual GameObject CreateStartingPoint() { return Resources.Load("StartingPoint") as GameObject; }
    public virtual GameObject CreateFinish() { return Resources.Load("Finish") as GameObject; }
    public virtual GameObject CreateCoin() { return Resources.Load("Coin") as GameObject; }
    public virtual GameObject CreateEnemy() { return Resources.Load("Enemy") as GameObject; }
    public virtual GameObject CreatePowerUpJump() { return Resources.Load("PowerUpJump") as GameObject; }
    public virtual GameObject CreatePowerUpLeft() { return Resources.Load("PowerUpLeft") as GameObject; }
    public virtual GameObject CreatePowerUpRight() { return Resources.Load("PowerUpRight") as GameObject; }
    public virtual GameObject CreatePowerUpTeleport () { return Resources.Load("PowerUpTeleport") as GameObject; }
    public virtual GameObject CreatePowerUpClone () { return Resources.Load("PowerUpClone") as GameObject; }
    public virtual GameObject CreateDestructiblePlatform() { return Resources.Load("DestructiblePlatform") as GameObject; }
    public virtual GameObject CreateWall() { return Resources.Load("DefaultWall") as GameObject; }
    public virtual GameObject CreateButton() { return Resources.Load("Button") as GameObject; }
    public virtual GameObject CreateGate() { return Resources.Load("Gate") as GameObject; }

}
