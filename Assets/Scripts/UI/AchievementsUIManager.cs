using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AchievementsUIManager : MonoBehaviour
{
    public GameObject achievementPrefab;
    public void OnEnable()
    {
        foreach (var item in AchievementsManager.instance.achievementList)
        {
            var temp = Instantiate(achievementPrefab, GameObject.FindGameObjectWithTag("Grid").transform);
            temp.GetComponent<AchievementUI>().achievementName = item.achievementName;
            temp.GetComponent<AchievementUI>().achievementText = item.description;
            var image = Resources.Load<Sprite>(item.spriteName);
            temp.GetComponent<AchievementUI>().achievementSprite = image;
            temp.GetComponent<AchievementUI>().isAchieved = item.unlocked;
            temp.GetComponent<AchievementUI>().Init();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
