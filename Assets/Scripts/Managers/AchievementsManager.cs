using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum AchievementType { Points, DieCount, CheckpointsCount, Event }

public class AchievementsManager : MonoBehaviour
{
    public List<Achievement> achievementList;
    public static  AchievementsManager instance = null;
    public GameObject achievManager;
    public List<Sprite> achievementSprites;
    public GameObject achievementPopupPrefab;
    public Transform achievementPopUpPlace;


    private AchievementsManager() { }

    void Start()
    { 
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
           Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        achievementList = new List<Achievement>();
        CreateAchievementFile();
    }

    private void CreateAchievementFile()
    {
        GameManagerScript.instance.gameAchievements.Clear();
        if (!File.Exists(Application.streamingAssetsPath + "/osiagniecia.JSON"))
        {
            int i = 0;
            CreateAchievementsList();
            StreamWriter sw = File.CreateText(Application.streamingAssetsPath + "/osiagniecia.JSON");
            foreach (var achievement in achievementList)
            {
                sw.WriteLine(SaveManager.CreateJsonString<Achievement>(achievement));
                achievement.index = i;
                if (achievement.unlocked == false)
                {
                    GameManagerScript.instance.AddObserver(achievement);
                }
                i++;
            }
            sw.Close();
        }
        else
        {
            LoadAchievementFromFile();
        }
    }

    private void LoadAchievementFromFile() {
        int i = 0;
        string line;
        StreamReader file = new StreamReader(Application.streamingAssetsPath + "/osiagniecia.JSON");
        while ((line = file.ReadLine()) != null)
        {
            Achievement achievement = JsonUtility.FromJson<Achievement>(line);
            achievementList.Add(achievement);
            achievement.index = i;
            i++;
            if (achievement.unlocked == false)
            {
                GameManagerScript.instance.AddObserver(achievement);
            }
        }
        file.Close();
    }


    public void SaveAchievementList()
    {
        StreamWriter sw = File.CreateText(Application.streamingAssetsPath + "/osiagniecia.JSON");
        foreach (var achievement in achievementList)
        {
            sw.WriteLine(SaveManager.CreateJsonString<Achievement>(achievement));
        }
        sw.Close();
    }

    public void CreateAchievementsList()
    {
        achievementList = new List<Achievement>();
        achievementList.Add(new Achievement(AchievementType.Points, "1 milion trzeba ukraść", "Zbierz swoją pierwszą monete!", 1, "AchievementGraphicCoin"));
        achievementList.Add(new Achievement(AchievementType.Points, "Hajs z komuni", "Zbierz 10 monet.", 10, "AchievementGraphicCoin"));
        achievementList.Add(new Achievement(AchievementType.Points, "Hajs sie zgadza!", "Zbierz 50 monet", 50, "AchievementGraphicCoin"));
        achievementList.Add(new Achievement(AchievementType.Points, "Od pucybuta do milionera!", "Zbierz 100 monet", 100, "AchievementGraphicCoin"));
        achievementList.Add(new Achievement(AchievementType.DieCount, "Zginełem!", "Zgiń po raz pierwszy", 1, "AchievementGraphicDead"));
        achievementList.Add(new Achievement(AchievementType.DieCount, "Penta...die!", "Zgiń po raz drugi", 2, "AchievementGraphicDead"));
        achievementList.Add(new Achievement(AchievementType.DieCount, "You died...10 times.", "Zgiń 10 razy", 10, "AchievementGraphicDead"));
        achievementList.Add(new Achievement(AchievementType.DieCount, "Brak miejsc na cmentarzu", "Zgiń 100 razy", 100, "AchievementGraphicDead"));
    }

    public void Unsubscribe(Achievement achievement)
    {
        achievementList[achievement.index].unlocked = true;
        achievement.unlocked = true;
        GameManagerScript.instance.RemoveObserver(achievement);
        SaveAchievementList();
        AchievementPopup(achievement);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (FindObjectOfType<AchievementsUIManager>())
        {
            achievManager = FindObjectOfType<AchievementsUIManager>().gameObject;
            achievManager.SetActive(true);
        }
    }

    public void AddAchievementsToGameManager()
    {
        foreach (var achievement in achievementList)
        {
            if (achievement.unlocked == false)
            {
                GameManagerScript.instance.AddObserver(achievement);
            }
        }
    }

    public void AchievementPopup(Achievement achievement)
    {
        var temp = Instantiate(achievementPopupPrefab, GameObject.FindGameObjectWithTag("AchievementPopup").transform);
        temp.GetComponent<AchievementPopup>().achievementPopupName = achievement.achievementName;
        var image = Resources.Load<Sprite>(achievement.spriteName);
        temp.GetComponent<AchievementPopup>().achievementPopupSprite = image;
        temp.GetComponent<AchievementPopup>().Init();
        StartCoroutine(WaitForDestroy(temp));
    }

    IEnumerator WaitForDestroy(GameObject achievementPopup)
    {
        yield return new WaitForSeconds(10);
        Destroy(achievementPopup);

    }
}


