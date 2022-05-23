using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileHandler : MonoBehaviour
{
    PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = new PlayerData();
    }
    public void SaveData(int level)
    {
        playerData.SetLevelData(level);
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);

        Debug.Log(playerData.GetLevelData());
    }
    public void LoadData()
    {
        string jsonfile = File.ReadAllText(Application.dataPath + "/saveFile.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(jsonfile);
        Debug.Log(loadedPlayerData.GetLevelData());
    }
    private class PlayerData
    {
        //public int maxHitpoint;
        private int reachedLevel;
        public void SetLevelData(int level)
        {
            reachedLevel = level;
            
        }
        public int GetLevelData()
        {
            return reachedLevel;
        }

    }

}
