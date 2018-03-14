using UnityEngine;

public class Achievement : IObserver
{
    public int intValueToUnlock;
    public bool boolValueToUnlock;
    public string description;
    public string achievementName;
    public string spriteName;
    public AchievementType type;
    public bool unlocked;
    public int index;

    public Achievement(AchievementType type, string achievementName, string description, int intValueToUnlock, string spriteName)
    {
        this.type = type;
        this.description = description;
        this.achievementName = achievementName;
        this.intValueToUnlock = intValueToUnlock;
        this.boolValueToUnlock = false;
        this.unlocked = false;
        this.spriteName = spriteName;
    }

    public Achievement(AchievementType type, string achievementName, string description, bool boolValueToUnlock, string spriteName)
    {
        this.type = type;
        this.description = description;
        this.achievementName = achievementName;
        this.intValueToUnlock = -1;
        this.boolValueToUnlock = boolValueToUnlock;
        this.unlocked = true;
        this.spriteName = spriteName;
    }

    public void OnNotify(Stats stats)
    {
        switch (type)
        {
            case AchievementType.Points:
                {
                    if (intValueToUnlock == stats.points)
                    {
                        UnlockAchievement();
                    }
                }
                break;
            case AchievementType.DieCount:
                {
                    if (intValueToUnlock == stats.dieCount)
                    {
                        UnlockAchievement();
                    }
                }
                break;
            case AchievementType.CheckpointsCount:
                break;
            case AchievementType.Event:
                break;
            default:
                break;
        }
    }

    public void UnlockAchievement()
    {   
        AchievementsManager.instance.Unsubscribe(this);
    }

    public void Print() {
        Debug.Log(description);
        Debug.Log(intValueToUnlock);
        Debug.Log(boolValueToUnlock);
        Debug.Log(type);
    }
}
