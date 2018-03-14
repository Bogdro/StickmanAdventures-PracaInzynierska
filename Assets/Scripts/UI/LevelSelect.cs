using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] buttons;
    private int levelUnlocked;
    public int counter;
    private bool m_isAxisInUse = false;

    public Button activeButton;

    public Sprite openSprite;

    private void Start()
    {
        if (GameManagerScript.instance.playerStats.finishedLevels > GameManagerScript.instance.gameStats.finishedLevels)
        {
            GameManagerScript.instance.gameStats.finishedLevels = GameManagerScript.instance.playerStats.finishedLevels;
        }
        GameManagerScript.instance.SaveGame();
        GameManagerScript.instance.SaveStats();
        for (int i = 0; i < GameManagerScript.instance.playerStats.finishedLevels; i++)
        {
            buttons[i+1].interactable = true;
            buttons[i + 1].GetComponent<Image>().sprite = openSprite;
            buttons[i+1].gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }
        activeButton = buttons[0];
        activeButton.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape))
        {
            
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (counter < GameManagerScript.instance.playerStats.finishedLevels)
            {
                activeButton.transform.GetChild(1).gameObject.SetActive(false);
                counter++;
                activeButton = buttons[counter];
                activeButton.transform.GetChild(1).gameObject.SetActive(true);
               
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!m_isAxisInUse)
            {
                if (counter < GameManagerScript.instance.playerStats.finishedLevels)
                {
                    activeButton.transform.GetChild(1).gameObject.SetActive(false);
                    counter++;
                    activeButton = buttons[counter];
                    activeButton.transform.GetChild(1).gameObject.SetActive(true);
                }
                m_isAxisInUse = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (counter <= GameManagerScript.instance.playerStats.finishedLevels && counter > 0)
            {
                activeButton.transform.GetChild(1).gameObject.SetActive(false);
                counter--;
                activeButton = buttons[counter];
                activeButton.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (!m_isAxisInUse)
            {
                if (counter <= GameManagerScript.instance.playerStats.finishedLevels && counter > 0)
                {
                    activeButton.transform.GetChild(1).gameObject.SetActive(false);
                    counter--;
                    activeButton = buttons[counter];
                    activeButton.transform.GetChild(1).gameObject.SetActive(true);
                }
                m_isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Horizontal") == 0) m_isAxisInUse = false;
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            activeButton.onClick.Invoke();
        }
        
    }

    
}

