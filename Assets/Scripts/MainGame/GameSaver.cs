using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class GameSaver : MonoBehaviour
{
    public GameManager gameManager;
    public string currentPlayerName;


    [SerializeField] private Leaderboard leaderboardScript;
    private string leaderboardInfoStr;
    public string playerName;
    public int playerScore;

    private string pathPlayerProfile;
    private string pathLeaderboard;
    private void Awake()
    {
        pathPlayerProfile = Application.persistentDataPath + "/player_savefile.json";
        pathLeaderboard = Application.persistentDataPath + "/leaderboard_savefile.json";
        playerName = leaderboardScript.playerName;
        playerScore = leaderboardScript.playerScore;
    }

    private void Start()
    {
        currentPlayerName = "John";
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    class PlayerProfile
    {
        public string playerName;
        public int playerScore;
    }
    [System.Serializable]
    class LeaderboardSaveData
    {
        public string leaderboardInfoStr;
    }

    public void SavePlayerData()
    {
        PlayerProfile playerSaveData = new PlayerProfile();
        playerName = leaderboardScript.playerName;
        playerSaveData.playerName = playerName;
        playerScore = leaderboardScript.playerScore;
        playerSaveData.playerScore = playerScore;

        string jsonPlayerData = JsonUtility.ToJson(playerSaveData);
        File.WriteAllText(pathPlayerProfile, jsonPlayerData);
        
        LeaderboardSaveData leaderboardSaveData = new LeaderboardSaveData();
        
        leaderboardInfoStr = JsonHelper.ToJson(leaderboardScript.leaderboardArray, true);
        
        leaderboardSaveData.leaderboardInfoStr = leaderboardInfoStr;
        string jsonLeaderboardData = JsonUtility.ToJson(leaderboardSaveData);
        File.WriteAllText(pathLeaderboard, jsonLeaderboardData);
        Debug.Log("Game saved!");
    }
    public void LoadPlayerData()
    {
        if (File.Exists(pathPlayerProfile))
        {
            string jsonPlayerData = File.ReadAllText(pathPlayerProfile);
            PlayerProfile playerSaveData = JsonUtility.FromJson<PlayerProfile>(jsonPlayerData);
            playerName = playerSaveData.playerName;
            playerScore = playerSaveData.playerScore;
        }
        if (File.Exists(pathLeaderboard))
        {
            string jsonLeaderboardData = File.ReadAllText(pathLeaderboard);
            LeaderboardSaveData leaderboardSaveData = JsonUtility.FromJson<LeaderboardSaveData>(jsonLeaderboardData);
            //LeaderboardSaveData leaderboardSaveData = JsonHelper.FromJson<InputEntry.Leaderboard>(jsonLeaderboardData);
            leaderboardScript.leaderboardArray = JsonHelper.FromJson<InputEntry.Leaderboard>(leaderboardSaveData.leaderboardInfoStr);
            Debug.Log("Game loaded!");
        }
    }

}
