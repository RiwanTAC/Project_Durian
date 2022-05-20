using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    //1- Variable
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    //2- Void Start
    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    //3- Void Update
    private void Update()
    {
        //Checking if the escape Key was pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Checking if the game is already pause or not
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    //4- Void Resume
    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        gameIsPaused = false;

    }

    //5- Void Pause
    public void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        gameIsPaused = true;

    }

    //6- Void Quit
    public void Quit()
    {

        print("Quitting game...");
        Application.Quit();

    }

}
