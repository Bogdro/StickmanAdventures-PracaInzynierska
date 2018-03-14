using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelType { Ground, Air }

public enum ObjectType { platform, movingPlatformYP, checkpoint, start, finish,
                        coin, enemy, leftPowerUp, rightPowerUp, jumpPowerUp,
                        clonePowerup, teleportPowerUp, destruciblePlatform, defaultWall,
                        gate, button}

[System.Serializable]
public class ColorToType {
    public Color color;
    public ObjectType type;
}

public class LevelGenerator : MonoBehaviour
{
    
    public LevelType levelType;
    public ColorToType[] typeMappings;

    private Texture2D map;
    private AbstractLevelFactory factory;

    private void Awake()
    {
        switch (levelType)
        {
            case LevelType.Ground:
                factory = new DefaultLevelFactory();
                break;
            case LevelType.Air:
                factory = new AirLevelFactory();
                break;
        }
    }

    public void GenerateLevel(Texture2D map)
    {
        this.map = map;
        for (int i = 0; i < map.width; i++)
        {
            for (int j = 0; j < map.height; j++)
            {
                GenerateTile(i, j);
            }
        }
    }

    private void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        ObjectType type = new ObjectType();

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToType typeMap in typeMappings) {
            if (pixelColor.Equals(typeMap.color))
                type = typeMap.type;
        }

        switch (type)
        {
            case ObjectType.platform:
                InstantiatePrefab(x, y, factory.CreatePlatform());
                break;
            case ObjectType.movingPlatformYP:
                InstantiatePrefab(x, y, factory.CreateMovingPlatformYP());
                break;
            case ObjectType.checkpoint:
                InstantiatePrefab(x, y, factory.CreateCheckpoint());
                break;
            case ObjectType.start:
                InstantiatePrefab(x, y, factory.CreateStartingPoint());
                break;
            case ObjectType.finish:
                InstantiatePrefab(x, y, factory.CreateFinish());
                break;
            case ObjectType.coin:
                InstantiatePrefab(x, y, factory.CreateCoin());
                break;
            case ObjectType.enemy:
                InstantiatePrefab(x, y, factory.CreateEnemy());
                break;
            case ObjectType.leftPowerUp:
                InstantiatePrefab(x, y, factory.CreatePowerUpLeft());
                break;
            case ObjectType.rightPowerUp:
                InstantiatePrefab(x, y, factory.CreatePowerUpRight());
                break;
            case ObjectType.jumpPowerUp:
                InstantiatePrefab(x, y, factory.CreatePowerUpJump());
                break;
            case ObjectType.clonePowerup:
                InstantiatePrefab(x, y, factory.CreatePowerUpClone());
                break;
            case ObjectType.teleportPowerUp:
                InstantiatePrefab(x, y, factory.CreatePowerUpTeleport());
                break;
            case ObjectType.destruciblePlatform:
                InstantiatePrefab(x, y, factory.CreateDestructiblePlatform());
                break;
            case ObjectType.defaultWall:
                InstantiatePrefab(x, y, factory.CreateWall());
                break;
            case ObjectType.gate:
                InstantiatePrefab(x, y, factory.CreateGate());
                break;
            case ObjectType.button:
                InstantiatePrefab(x, y, factory.CreateButton());
                break;
            default:
                break;
        }
    }

    private void InstantiatePrefab(int x, int y, GameObject prefab) {
        Instantiate(prefab, new Vector2(x, y), Quaternion.identity);
    }  
}
