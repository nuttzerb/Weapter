using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuCanvas : MonoBehaviour
{
    public static bool gameIsPause = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject SelectMenuUI;
    [SerializeField] GameObject victoryMenu;
    [SerializeField] GameObject deadMenu;
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
    private void GameIsPause(bool boolean, int timescale)
    {
        pauseMenuUI.SetActive(boolean);
        Time.timeScale = timescale;
        gameIsPause = boolean;
    }   
    public void Resume()
    {
        GameIsPause(false,1);
    }
    public void Pause()
    {
        GameIsPause(true,0);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        SelectMenuUI.SetActive(false);
        victoryMenu.SetActive(false);
        deadMenu.SetActive(false);
        GameManager.instance.ResetPlayerStats();

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
    public void PlayAgain()
    {
        victoryMenu.SetActive(false);
        deadMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.ResetPlayerStats();
        SceneManager.LoadScene(1);
    }
    public void Retry()
    {
        GameManager.instance.ResetPlayerStats();
        deadMenu.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.ResetPlayerStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Exit()
    {
        Application.Quit();
    }
} 
