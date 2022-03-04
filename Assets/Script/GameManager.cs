using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    //resources
    public List<Sprite> playerSprites;

    //references
    public Player player;
    public PlayerHealth playerHealth;
   // public Weapon weapon;
    //public GameObject floatingTextManager;
    /*  public Animator deadMenuAnimator;
      public Animator resultMenuAnimator;
      public Animator characterMenuAnimator;*/
    // public ResultMenu resultMenu;

    // int enemyCount = 0;
    public int coins;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
      //      Destroy(floatingTextManager.gameObject);
            return;
        }
         instance = this; // quan trong
                          //   ResetState();
      playerHealth.SetMaxHealth(player.maxHitpoint);
        /* SceneManager.sceneLoaded += LoadState;
         DontDestroyOnLoad(gameObject);*/
    }

    public void ShowText(string text,  Color color, Vector3 position, float duration)
    {
        //floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public void Hide()
    {
/*        deadMenuAnimator.SetTrigger("hide");
        resultMenuAnimator.SetTrigger("hide");
        characterMenuAnimator.SetTrigger("hide");*/
    }

    public void ResetPlayerStats()
    {
        player.maxHitpoint = 3;
        player.hitpoint = player.maxHitpoint;
  //      player.playerProjectile.damagePoint = 1;

    }
    public void Respawn()
    {
        Hide();
      //  SceneManager.LoadScene("PrepareRoom");
        player.isAlive = true;
        ResetPlayerStats();
        ResetState();
    }
    public void ReturnMenu()
    {
        ResetPlayerStats();
        ResetState();
        Hide();
        player.isAlive = true;
    //    SceneManager.LoadScene("Menu");
    }
    /*
     * playerskin
     * coin
     * exp
     * weapon level
     */
    public void SaveState()
    {
        string s = "";
        s += "0" + "|"; //player skin
        s += coins.ToString() + "|";
     //   s += experience.ToString() + "|";
     //   s += weapon.weaponLevel.ToString();
        //s += player.hitpoint.ToString();
        PlayerPrefs.SetString("SaveState", s);
        //   Debug.Log("SaveState");
    }
    public void ResetState()
    {
        string s = "";
        s += "0" + "|"; //skin
        s += "0" + "|";// coin
        s += "0" + "|";//exp
        s += "0";//weapon level
                 // s += "0"; //hit point
        PlayerPrefs.SetString("SaveState", s);
        //  Debug.Log("ResetState");
    }
/*    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        // change player skin
        coins = int.Parse(data[1]);
        //experience
        experience = int.Parse(data[2]);
        *//*        if (GetCurrentLevel() != 1)
                    player.SetLevel(GetCurrentLevel());*//*
        //change weapon level
        weapon.SetWeaponLevel(weapon.weaponLevel = int.Parse(data[3]));
        //  player.hitpoint = int.Parse(data[4]);
        //  Debug.Log("LoadState");
        if (!GameObject.Find("SpawnPoint")) return;
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;

    }*/
}
