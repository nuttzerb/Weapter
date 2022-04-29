using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButton;
    int level;
    int reachedLevel = 1;
    [SerializeField] GameObject SelectMenu;
    void Awake()
    {
        // two key: Reached Level and Level
        //Reached level tang theo level
        // Level tang dan
        //UnlockLevel();
        if (reachedLevel == 0) level = PlayerPrefs.GetInt("Level", 2);
        else reachedLevel = level;
        Debug.Log(reachedLevel);

    }
    private void Update()
    {

    }
    public void UnlockLevel()
    {

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
