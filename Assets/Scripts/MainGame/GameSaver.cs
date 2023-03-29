using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class GameSaver : MonoBehaviour
{
    private GameManager gameManager;
    public string currentPlayerName;
    //private InputEntry.Leaderboard[] leaderboardArray = new InputEntry.Leaderboard[10];

    [SerializeField] private Leaderboard leaderboardScript;
    private string jsonSaveData;

    private void Start()
    {
        currentPlayerName = "John";
        jsonSaveData = leaderboardScript.jsonSaveData;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    [System.Serializable]
    class SaveData
    {
        public string jsonSaveData;
    }

    public void SavePlayerData()
    {
        for (int i = 0; i < leaderboardScript.leaderboardArray.Length; i++)
        {
            Debug.Log(leaderboardScript.leaderboardArray[i]);
        }
        string path = Application.persistentDataPath + "/savefile.json";
        SaveData data = new SaveData();
        jsonSaveData = JsonHelper.ToJson(leaderboardScript.leaderboardArray, true);
        data.jsonSaveData = jsonSaveData;
        File.WriteAllText(path, jsonSaveData);
        Debug.Log("Game saved!");
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            SaveData data = new SaveData();
            data.jsonSaveData = File.ReadAllText(path);
            jsonSaveData = data.jsonSaveData;
            leaderboardScript.leaderboardArray = JsonHelper.FromJson<InputEntry.Leaderboard>(jsonSaveData);
            Debug.Log("Game loaded!");
        }
    }

}
