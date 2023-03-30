using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Transform playerList;

    [SerializeField] private GameObject playerTemplatePrefab;

    [SerializeField] private InputController inputController;

    private const int leadersNumber = 10;

    public InputEntry.Leaderboard[] leaderboardArray = new InputEntry.Leaderboard[leadersNumber+1];
    
    public string playerName;
    public int playerScore;
    public string currentPlayerScore;

    public int PlayerPlace { get; private set; }

    private void Start()
    {
        BubbleSortByScore();
        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        for (int i = 0; i < leaderboardArray.Length; i++)
        {
            PlayerPlace = i + 1;
            GameObject playerPosition = Instantiate(playerTemplatePrefab, playerList);
            playerPosition.GetComponent<LeaderboardPlayerScore>().place = PlayerPlace;
            if (!String.IsNullOrEmpty(leaderboardArray[i].leaderboardPlayerName) && PlayerPlace != 11)
            {
                playerPosition.SetActive(true);
            }
        }
    }

    public void BubbleSortByScore()
    {
        string tempPlayerName = "";
        int tempPlayerScore = 0;

        for (int write = 0; write < leaderboardArray.Length; write++)
        {
            for (int sort = 0; sort < leaderboardArray.Length - 1; sort++)
            {
                if (leaderboardArray[sort].leaderboardPlayerScore < leaderboardArray[sort + 1].leaderboardPlayerScore)
                {
                    tempPlayerName = leaderboardArray[sort + 1].leaderboardPlayerName;
                    tempPlayerScore = leaderboardArray[sort + 1].leaderboardPlayerScore;
                    leaderboardArray[sort + 1].leaderboardPlayerName = leaderboardArray[sort].leaderboardPlayerName;
                    leaderboardArray[sort + 1].leaderboardPlayerScore = leaderboardArray[sort].leaderboardPlayerScore;
                    leaderboardArray[sort].leaderboardPlayerName = tempPlayerName;
                    leaderboardArray[sort].leaderboardPlayerScore = tempPlayerScore;
                }
            }
        }
    }

    public void ArrayInitialization()
    {
        for (int i = 0; i < leaderboardArray.Length; i++)
        {
            leaderboardArray[i] = new InputEntry.Leaderboard();
        }

    }

    private void RandomArrayInput()
    {
        for (int i = 0; i < leaderboardArray.Length; i++)
        {
            leaderboardArray[i] = new InputEntry.Leaderboard
            {
                leaderboardPlayerName = i.ToString(),
                leaderboardPlayerScore = Random.Range(0, 999)
            };
        }
    }

    public void AddPlayerToLeaderboard()
    {
        if (playerScore > 0)
        {
            if (IsPlayerExists())
            {
                ReplacePlayer();
            }
            if (!IsPlayerExists())
            {
                AddPlayer();
            }
        }
    }

    private bool IsPlayerExists()
    {
        for (int i = 0; i < leaderboardArray.Length; i++)
        {
            if (playerName == leaderboardArray[i].leaderboardPlayerName)
            {
                return true;
            }
        }

        return false;
    }
    private void AddPlayer()
    {
        leaderboardArray[leadersNumber].leaderboardPlayerName = playerName;
        leaderboardArray[leadersNumber].leaderboardPlayerScore = playerScore;
    }
    private void ReplacePlayer()
    {
        for (int i = 0; i < leaderboardArray.Length; i++)
        {
            if (leaderboardArray[i].leaderboardPlayerName == playerName && playerScore > leaderboardArray[i].leaderboardPlayerScore)
            {
                leaderboardArray[i].leaderboardPlayerScore = playerScore;
            }
        }
    }
}

public class InputEntry
{
    public string playerName;
    public int playerScore;
    public string currentPlayerScore;
    [Serializable]
    public class Leaderboard
    {
        public string leaderboardPlayerName;
        public int leaderboardPlayerScore;
    }


    [Serializable]
    public class CurrentPlayerData
    {
        public string playerName;
        public int playerScore;
        public string currentPlayerScore;
    }
}
