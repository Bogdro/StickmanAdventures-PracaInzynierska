using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLevelFactory : AbstractLevelFactory{
    public override GameObject CreatePlatform()
    {
        return Resources.Load("CloudPlatform") as GameObject;
    }

    public override GameObject CreateMovingPlatformYP()
    {
        return Resources.Load("CloudMovingPlatformYP") as GameObject;
    }
}
