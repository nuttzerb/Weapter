using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject SelectMenuUI;

    private void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }*/
    }
   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

   public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void LevelSelect()
    {
        pauseMenuUI.SetActive(false);
        SelectMenuUI.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void BackToPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        SelectMenuUI.SetActive(false);
    }
} 
