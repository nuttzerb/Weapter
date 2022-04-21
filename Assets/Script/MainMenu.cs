using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject CharacterMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ShowCharacterMenu()
    {
        CharacterMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void HideCharacterMenu()
    {
        CharacterMenu.SetActive(false);
        this.gameObject.SetActive(true);

    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
