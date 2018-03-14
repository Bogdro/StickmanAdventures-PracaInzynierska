using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerScript : MonoBehaviour, IObservable {

    public static GameManagerScript instance;
    public Stats gameStats;
    public Stats playerStats;
    public Player player;
    public List<IObserver> gameAchievements;
    public int[] levelsUnlocked;

    private GameManagerScript() { }

    void Awake() {

        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
        levelsUnlocked = new int[20];
        levelsUnlocked[0] = 1;
        NewLevelList();
        DontDestroyOnLoad(gameObject);


        if (File.Exists(Application.streamingAssetsPath + "/gameStats"))
        {
            gameStats = SaveManager.LoadObject<Stats>("gameStats");
        }
        else
        {
            gameStats = new Stats();
        }
        gameAchievements = new List<IObserver>();
    }

    public void NewLevelList()
    {
        levelsUnlocked = new int[20];
        levelsUnlocked[0] = 1;
    }
    public void SaveGame()
    {
        SaveManager.Save<Stats>(playerStats, "savedGame");
    }
    public void SaveStats()
    {
        SaveManager.Save<Stats>(gameStats, "gameStats");
    }
    public void LoadGame() {
        if (File.Exists(Application.streamingAssetsPath + "/savedGame"))
        {

            playerStats = SaveManager.LoadObject<Stats>("savedGame");
        }
        else
        {
            //Jesli nie ma pliku to przycisk jest nieaktywny.
            gameStats = new Stats();
            Debug.Log("Nowa Gra");
        }
    }
    public void NewGame()
    {
        playerStats = new Stats();
        playerStats.lives = 3;
    }

    #region gameAchievements
    public void AddObserver(IObserver observer)
    {
        gameAchievements.Add(observer);
    }

    public void NotifyObservers()
    {
        foreach (var gameAchievement in gameAchievements.ToArray())
        {
            gameAchievement.OnNotify(gameStats);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        gameAchievements.Remove(observer);
    }
    #endregion

}
