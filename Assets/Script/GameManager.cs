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
    public FileHandler gameHandler;
    [Header("UI")]
    public GameObject canvas;
    public GameObject menuCanvas;
    public GameObject HUD;
    public FloatingTextManager floatingTextManager;
    public LevelSelection levelSelection;
    public GameObject characterMenu;
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
            Destroy(HUD);
            Destroy(canvas);
            Destroy(characterMenu);
            return;
        }
         instance = this; // quan trong

        cameraShake = FindObjectOfType<CameraShake>().GetComponent<CameraShake>();

        SceneManager.sceneLoaded += LoadState;

        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(cameraShake);
        DontDestroyOnLoad(HUD);
        DontDestroyOnLoad(menuCanvas);
        DontDestroyOnLoad(characterMenu);
    }
    private void Update()
    {
        HideHUD();
    }
    public void HideHUD()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            HUD.SetActive(false);
        }
        else
        {
            HUD.SetActive(true);
        }
    }
    public void ShowText(string msg, int fontSize,  Color color, Vector3 position,Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public void ResetPlayerStats()
    {
        player.hitpoint = player.maxHitpoint;
        player.playerHealthUI.SetMaxHealth(player.maxHitpoint);
        player.isAlive=true;
    }

    public void SaveState()
    {
        string s = "";
        s += "0" + "|"; //player skin
        s += coins.ToString() + "|";
        //s += player.hitpoint.ToString();
        PlayerPrefs.SetString("SaveState", s);
     //   Debug.Log("SaveState");
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        //  Debug.Log("LoadState");
        if (!GameObject.Find("StartPoint")) return;
        player.transform.position = GameObject.Find("StartPoint").transform.position;
    }
}
