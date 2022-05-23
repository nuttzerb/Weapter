using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    int nextSceneLoad;
    public bool winning=false;
    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if (nextSceneLoad > PlayerPrefs.GetInt("reachedLevel"))
            {
                GameManager.instance.levelSelection.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("reachedLevel", nextSceneLoad);
               
            }
            if (nextSceneLoad < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneLoad);
                GameManager.instance.gameHandler.SaveData(SceneManager.GetActiveScene().buildIndex + 1); 
            }
            if (SceneManager.sceneCountInBuildSettings== SceneManager.GetActiveScene().buildIndex+1)
            {
                ShowVictoryMenu();
            }
            GameManager.instance.SaveState();
        }
    }
    private static void ShowVictoryMenu()
    {
        GameManager.instance.totalTime.text = Time.time.ToString();
        GameManager.instance.goldCollected.text = GameManager.instance.coins.ToString();
        GameManager.instance.menuCanvas.transform.GetChild(2).gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
