using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Transform playerList;

    [SerializeField] private GameObject playerTemplate;

    public InputEntry.Leaderboard[] leaderboardArray = new InputEntry.Leaderboard[10];

    private const int leadersNumber = 10;

    public string jsonSaveData;

    private void Awake()
    {
        for (int i = 0; i < leaderboardArray.Length; i++)
        {
            Debug.Log(leaderboardArray[i]);
        }
        
        RandomArrayInput();
        BubbleSortByScore();
        
        for (int i = 0; i < leadersNumber; i++)
        {
            Instantiate(playerTemplate, playerList);
        }

    }

    private void BubbleSortByScore()
    {
        string tempPlayerName = "";
        int tempPlayerScore = 0;

        for (int write = 0; write < leaderboardArray.Length; write++) 
        {
            for (int sort = 0; sort < leaderboardArray.Length - 1; sort++) 
            {
                if (leaderboardArray[sort].playerScore > leaderboardArray[sort + 1].playerScore)
                {
                    tempPlayerName = leaderboardArray[sort + 1].playerName;
                    tempPlayerScore = leaderboardArray[sort + 1].playerScore;
                    leaderboardArray[sort + 1].playerName = leaderboardArray[sort].playerName;
                    leaderboardArray[sort + 1].playerScore = leaderboardArray[sort].playerScore;
                    leaderboardArray[sort].playerName = tempPlayerName;
                    leaderboardArray[sort].playerScore = tempPlayerScore;
                }
            }
        }
    }

    private void RandomArrayInput()
    {
        for (int i = 0; i < leaderboardArray.Length; i++)
        {
            leaderboardArray[i] = new InputEntry.Leaderboard();
            leaderboardArray[i].playerName = i.ToString();
            leaderboardArray[i].playerScore = Random.Range(0, 999);
        }
    }
}
