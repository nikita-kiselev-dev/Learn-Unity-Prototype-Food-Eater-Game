using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardPlayerScore : MonoBehaviour
{
    private Leaderboard leaderboardScript;
    [SerializeField] private TextMeshProUGUI playerPlace;
    private TextMeshProUGUI playerName;
    private TextMeshProUGUI playerScore;
    public int place;

    private void Awake()
    {
        leaderboardScript = GameObject.FindGameObjectWithTag("Leaderboard").GetComponent<Leaderboard>();
        playerPlace = gameObject.transform.Find("Player Place Header").GetComponent<TextMeshProUGUI>();
        playerName = gameObject.transform.Find("Player Name Header").GetComponent<TextMeshProUGUI>();
        playerScore = gameObject.transform.Find("Player Score Header").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        playerPlace.text = place.ToString();
        playerName.text = leaderboardScript.leaderboardArray[place-1].leaderboardPlayerName; 
        playerScore.text = leaderboardScript.leaderboardArray[place-1].leaderboardPlayerScore.ToString();
    }
}
