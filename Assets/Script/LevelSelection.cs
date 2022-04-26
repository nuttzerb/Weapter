using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButton;
    int level;
    [SerializeField] GameObject SelectMenu;
    void Awake()
    {
        // two key: Reached Level and Level
        //Reached level tang theo level
        // Level tang dan
        UnlockLevel();
    }
    private void Update()
    {
        UnlockLevel();
    }
    public void UnlockLevel()
    {
        level = PlayerPrefs.GetInt("Level", 2);
        int reachedLevel = level;
        for (int i = 0; i < lvlButton.Length; i++)
        {
            if (i + 2 > reachedLevel)
            {
                lvlButton[i].interactable = false;
            }
        }
    }

    public void LoadScene(int level)
    {
      //  PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(level);
        SelectMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
