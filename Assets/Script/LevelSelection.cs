using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButton;
    void Start()
    {
        // two key: Reached Level and Level
        int reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 2);
        if(PlayerPrefs.GetInt("Level") >=2 )
        {
            reachedLevel = PlayerPrefs.GetInt("Level");
        }

        for (int i = 0; i < lvlButton.Length; i++)
        {
            if(i+2 > reachedLevel)
            {
                lvlButton[i].interactable = false;
            }
        }
    }

    public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(level);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
