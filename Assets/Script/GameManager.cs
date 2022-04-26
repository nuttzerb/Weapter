using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Header("Reference")]
    public static GameManager instance;
    public Player player;
    public PlayerHealthUI playerHealthUI;
    public GameObject canvas;
    public GameObject menuCanvas;
    public GameObject HUD;
    public FloatingTextManager floatingTextManager;
    public LevelSelection levelSelection;
    [Header("Camera Shake")]
    public CameraShake cameraShake;
    public float duration=0.4f;
    public float magnitude=0.15f;
    [Header("Boss")]
    public Slider bossHealthSlider;
    [Header("Currency")]
    public int coins;
    public bool haveKey=false;
    [Header("Characters Select")]
    public List<Sprite> playerSprites;
    public RuntimeAnimatorController[] playerAnimation;
    [Header("Victory Menu")]
    public Text totalTime;
    public Text goldCollected;


    //resources


    /*  public Animator deadMenuAnimator;
      public Animator resultMenuAnimator;
      public Animator characterMenuAnimator;*/
    // public ResultMenu resultMenu;

    private void Awake()
    {


        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(cameraShake);
            return;
        }
         instance = this; // quan trong


        playerHealthUI.SetMaxHealth(player.maxHitpoint);

        cameraShake = FindObjectOfType<CameraShake>().GetComponent<CameraShake>();

        SceneManager.sceneLoaded += LoadState;

        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(cameraShake);
        DontDestroyOnLoad(HUD);
        DontDestroyOnLoad(menuCanvas);
    }

    public void ShowText(string msg, int fontSize,  Color color, Vector3 position,Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public void Hide()
    {
/*        deadMenuAnimator.SetTrigger("hide");
        resultMenuAnimator.SetTrigger("hide");
        characterMenuAnimator.SetTrigger("hide");*/
    }

    public void ResetPlayerStats()
    {
        player.maxHitpoint = 10;
        player.hitpoint = player.maxHitpoint;
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
        //s += player.hitpoint.ToString();
        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("SaveState");
    }
    public void ResetState()
    {

    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

          Debug.Log("LoadState");
//      PlayerPrefs.GetInt("Level");
        levelSelection.UnlockLevel();
        if (!GameObject.Find("StartPoint")) return;
        player.transform.position = GameObject.Find("StartPoint").transform.position;
    }
}
