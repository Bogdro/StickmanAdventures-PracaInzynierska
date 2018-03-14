using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenuUI;

    public Button[] buttons;

    public Button activeButton;

    public GameObject gameManager;

    public int counter;

    private bool m_isAxisInUse = false;


    private void Start()
    {
        counter = 0;
        activeButton = buttons[0];
        activeButton.transform.GetChild(1).gameObject.SetActive(true);

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (counter < buttons.Length - 1)
            {
                counter++;
                activeButton.transform.GetChild(1).gameObject.SetActive(false);
                activeButton = buttons[counter];
                activeButton.transform.GetChild(1).gameObject.SetActive(true);

            }
            else
            {
                counter = 0;
                activeButton.transform.GetChild(1).gameObject.SetActive(false);
                activeButton = buttons[counter];
                activeButton.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!m_isAxisInUse)
            {
                if (counter < buttons.Length - 1)
                {
                    counter++;
                    activeButton.transform.GetChild(1).gameObject.SetActive(false);
                    activeButton = buttons[counter];
                    activeButton.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    counter = 0;
                    activeButton.transform.GetChild(1).gameObject.SetActive(false);
                    activeButton = buttons[counter];
                    activeButton.transform.GetChild(1).gameObject.SetActive(true);
                }
                m_isAxisInUse = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (counter < buttons.Length && counter > 0)
            {
                counter--;
                activeButton.transform.GetChild(1).gameObject.SetActive(false);
                activeButton = buttons[counter];
                activeButton.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                counter = buttons.Length - 1;
                activeButton.transform.GetChild(1).gameObject.SetActive(false);
                activeButton = buttons[counter];
                activeButton.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (!m_isAxisInUse)
            {
                if (counter < buttons.Length && counter > 0)
                {
                    counter--;
                    activeButton.transform.GetChild(1).gameObject.SetActive(false);
                    activeButton = buttons[counter];
                    activeButton.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    counter = buttons.Length - 1;
                    activeButton.transform.GetChild(1).gameObject.SetActive(false);
                    activeButton = buttons[counter];
                    activeButton.transform.GetChild(1).gameObject.SetActive(true);
                }
                m_isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") == 0) m_isAxisInUse = false;

        if (Input.GetKeyDown(KeyCode.Return) && isPaused|| Input.GetKeyDown(KeyCode.Joystick1Button0) && isPaused)
        {
            activeButton.onClick.Invoke();
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        GameManagerScript.instance.SaveStats();
        GameManagerScript.instance.SaveGame();
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManagerScript.instance.SaveStats();
        GameManagerScript.instance.SaveGame();
        GameManagerScript.instance.playerStats = new Stats();
        GameManagerScript.instance.NewLevelList();
        SceneManager.LoadScene("MainMenu");
    }

 
}
