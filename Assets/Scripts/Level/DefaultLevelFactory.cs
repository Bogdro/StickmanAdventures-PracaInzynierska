using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLevelFactory : AbstractLevelFactory {
    public override GameObject CreatePlatform()
    { 
        return Resources.Load("DefaultPlatform") as GameObject;
    }

    public override GameObject CreateMovingPlatformYP()
    {
        return Resources.Load("MovingPlatformY") as GameObject;
    }
   
}
