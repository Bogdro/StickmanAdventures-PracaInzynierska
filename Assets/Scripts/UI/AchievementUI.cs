using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementUI : MonoBehaviour
{
    public Image achievementImageUI;
    public TextMeshProUGUI achievementNameUI, achievementTextUI;
    public string achievementName, achievementText;
    public Sprite achievementSprite;
    public bool isAchieved;
    public GameObject done;

    public void Init()
    {
        achievementImageUI.sprite = achievementSprite;
        achievementTextUI.text = achievementText;
        achievementNameUI.text = achievementName;
        if (isAchieved) done.SetActive(true);
    }
}
