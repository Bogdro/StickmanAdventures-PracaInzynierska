using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour
{
    public Image achievementPopupImageUI;
    public TextMeshProUGUI achievementPopupNameUI;
    public string achievementPopupName;
    public Sprite achievementPopupSprite;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Init()
    {
        achievementPopupImageUI.sprite = achievementPopupSprite;
        achievementPopupNameUI.text = achievementPopupName;

    }
}
