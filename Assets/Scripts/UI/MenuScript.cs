using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button[] buttons;

    public Button activeButton;

    public GameObject gameManager;

    public int counter;

    private bool m_isAxisInUse = false;

    private void Start()
    {

        counter = 0;
        activeButton = buttons[0];
        activeButton.GetComponentInChildren<Animation>().Play();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (counter < buttons.Length - 1)
            {
                counter++;
                activeButton.GetComponentInChildren<Animation>().Stop();
                activeButton = buttons[counter];
                activeButton.GetComponentInChildren<Animation>().Play();
                
            }
            else
            {
                counter = 0;
                activeButton.GetComponentInChildren<Animation>().Stop();
                activeButton = buttons[counter];
                activeButton.GetComponentInChildren<Animation>().Play();
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!m_isAxisInUse)
            {
                if (counter < buttons.Length - 1)
                {
                    counter++;
                    activeButton.GetComponentInChildren<Animation>().Stop();
                    activeButton = buttons[counter];
                    activeButton.GetComponentInChildren<Animation>().Play();
                }
                else
                {
                    counter = 0;
                    activeButton.GetComponentInChildren<Animation>().Stop();
                    activeButton = buttons[counter];
                    activeButton.GetComponentInChildren<Animation>().Play();
                }
                m_isAxisInUse = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (counter < buttons.Length && counter > 0)
            {
                counter--;
                activeButton.GetComponentInChildren<Animation>().Stop();
                activeButton = buttons[counter];
                activeButton.GetComponentInChildren<Animation>().Play();
            }
            else
            {
                counter = buttons.Length - 1;
                activeButton.GetComponentInChildren<Animation>().Stop();
                activeButton = buttons[counter];
                activeButton.GetComponentInChildren<Animation>().Play();
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (!m_isAxisInUse)
            {
                if (counter < buttons.Length && counter > 0)
                {
                    counter--;
                    activeButton.GetComponentInChildren<Animation>().Stop();
                    activeButton = buttons[counter];
                    activeButton.GetComponentInChildren<Animation>().Play();
                }
                else
                {
                    counter = buttons.Length - 1;
                    activeButton.GetComponentInChildren<Animation>().Stop();
                    activeButton = buttons[counter];
                    activeButton.GetComponentInChildren<Animation>().Play();
                }
                m_isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") == 0) m_isAxisInUse = false;
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            activeButton.onClick.Invoke();
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LaunchWorldMap()
    {
        Debug.Log("Nie zaimplementowane!");
    }

    public void LaunchMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LaunchOptions()
    {
        Debug.Log("Nie zaimplementowane!");
    }

    public void LoadGame()
    {
        FindObjectOfType<GameManagerScript>().LoadGame();
        SceneManager.LoadScene("LevelSelect");
    }

    public void NewGame()
    {
        FindObjectOfType<GameManagerScript>().NewGame();
        SceneManager.LoadScene("LevelSelect");
    }

    public void LaunchAchievments()
    {
        SceneManager.LoadScene("AchievmentsMenu");
    }
    
}
