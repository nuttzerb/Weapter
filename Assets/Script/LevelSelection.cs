using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButton;
    public int level;
    [SerializeField] GameObject SelectMenu;

    private void Start()
    {
        PlayerPrefs.GetInt("reachedLevel", 2);
        UnlockLevel(PlayerPrefs.GetInt("reachedLevel"));
    }
    public void UnlockLevel(int level)
    {
        for (int i = 0; i < lvlButton.Length; i++)
        {
            if (i + 2 > level)
            {
                lvlButton[i].interactable = false;
            }
            else
            {
                lvlButton[i].interactable = true;
            }
        }
    }
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
        GameManager.instance.ResetPlayerStats();
        GameManager.instance.bossHealthSlider.gameObject.SetActive(false);
        SelectMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
