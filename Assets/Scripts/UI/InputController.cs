using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputController : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameText;
    [SerializeField] private Leaderboard leaderboardScript;
    [SerializeField] private GameObject gameStartButtonGroup;
    
    public string playerName;

    public bool isPlayerNameNull;
    
    private void Start()
    {
        playerName = leaderboardScript.playerName;
        playerNameText.text = playerName;
        if (!IsPlayerNameEmpty())
        {
            gameStartButtonGroup.SetActive(true);
        }
    }

    void Update()
    {
        if (IsPlayerNameEmpty())
        {
            isPlayerNameNull = true;
        }
        else
        {
            isPlayerNameNull = false;
        }
    }

    public void SavePlayerName()
    {
        playerName = playerNameText.text;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void InstantiateDifficultyButtons()
    {
        if (!IsPlayerNameEmpty())
        {
            gameStartButtonGroup.SetActive(true);
        }
        else
        {
            gameStartButtonGroup.SetActive(false);
        }
    }

    public bool IsPlayerNameEmpty()
    {
        if (String.IsNullOrEmpty(playerNameText.text))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
