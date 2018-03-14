using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int levelNumber;
    public string nextLevelName;

    public bool canMoveRight, canMoveLeft, canJump, canTeleport, canClone;

    public GameObject playerInst;
    public List<GameObject> collectedCoins;
    public List<GameObject> collectedPowerUps;
    public LevelMemento checkPointMemento;

    public Texture2D map;

    public Stats levelStats;

    public GameObject[] platforms;

    public PlatformSpawner platformSpawner;
    public Transform spawnPoint;


    private int lastPlayerScore;
    private bool liveAdded;

    private Player player;
    private GameObject finishLine;
    private LevelGenerator levelGenerator;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
        levelGenerator.GenerateLevel(map);
        spawnPoint = GameObject.Find("StartingPoint(Clone)").transform;
        liveAdded = false;

        player = Instantiate(playerInst, spawnPoint.position, Quaternion.identity).GetComponent<Player>();
      
        platforms = GameObject.FindGameObjectsWithTag("DestructiblePlatform");
        platformSpawner = FindObjectOfType<PlatformSpawner>();

        DecoratePlayer();
    }

    private void Update()
    {
        if (player != null)
        {
            if (player.transform.position.y < -2)
            {
                Destroy(player.gameObject);
                if (player.cloned) Destroy(GameObject.FindGameObjectWithTag("PlayerClone"));
                RespawnPlayer(checkPointMemento);
            }
        }

        if (GameManagerScript.instance.playerStats.points == 10)
        {
            GameManagerScript.instance.playerStats.points = 0;
            GameManagerScript.instance.playerStats.lives++;
            liveAdded = true;
        }
    }

    public void RespawnPlayer(LevelMemento memento) {

        if (GameManagerScript.instance.playerStats.lives > 0)
        {
            GameManagerScript.instance.playerStats.lives--;
            GameManagerScript.instance.gameStats.dieCount++;
            GameManagerScript.instance.playerStats.dieCount++;
            GameManagerScript.instance.NotifyObservers();
            GameManagerScript.instance.SaveStats();
            player = Instantiate(playerInst, memento.checkpointPosition.position, memento.checkpointPosition.rotation).GetComponent<Player>();
        }

        else
        {
            GameOver();
        }

        foreach (var coin in memento.collectedCoins)
        {
            coin.SetActive(true);
        }

        foreach (var powerUp in memento.collectedPowerUps)
        {
            powerUp.SetActive(true);
        }

        foreach (var platform in platforms)
        {
            platformSpawner.SpawnPlatform(platform);
        }

        canJump = memento.canJump;
        canMoveLeft = memento.canMoveLeft;
        canMoveRight = memento.canMoveRight;
        canTeleport = memento.canTeleport;
        canClone = memento.canClone;
        DecoratePlayer();
        GameManagerScript.instance.playerStats.points = lastPlayerScore;
        
    }

    public void DecoratePlayer()
    {
        player.movementObject = new IdleMovement();
        if (canMoveLeft)player.movementObject = new MoveLeft(player.movementObject);
        if (canMoveRight)player.movementObject = new MoveRight(player.movementObject);
        if (canJump)player.movementObject = new Jump(player.movementObject);
        if (canTeleport) player.movementObject = new Teleport(player.movementObject);
        if (canClone) player.movementObject = new Clone(player.movementObject);
    }

    public void CreateMemento(Transform checkPointTransform)
    {
        if (liveAdded)
        {
            GameManagerScript.instance.playerStats.lives--;
            liveAdded = false;
        }
        lastPlayerScore = GameManagerScript.instance.playerStats.points;
        collectedCoins.Clear();
        collectedPowerUps.Clear();
        checkPointMemento = new LevelMemento();
        checkPointMemento.checkpointPosition = checkPointTransform;
        checkPointMemento.collectedCoins = collectedCoins;
        checkPointMemento.collectedPowerUps = collectedPowerUps;
        checkPointMemento.canJump = canJump;
        checkPointMemento.canMoveLeft = canMoveLeft;
        checkPointMemento.canMoveRight = canMoveRight;
        checkPointMemento.canTeleport = canTeleport;
        checkPointMemento.canClone = canClone;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    public IEnumerator LoadLevel()
    {
        Time.timeScale = 0;
        new WaitForSeconds(2);
        Time.timeScale = 1;
        SceneManager.LoadScene(nextLevelName);
        yield return 0;
    }
}
