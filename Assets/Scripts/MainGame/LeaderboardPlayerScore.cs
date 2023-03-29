using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardPlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerPlace;
    private TextMeshProUGUI playerName;
    private TextMeshProUGUI playerScore;
    
    private void Start()
    {
        playerPlace = gameObject.transform.Find("Player Place Header").GetComponent<TextMeshProUGUI>();
        playerName = gameObject.transform.Find("Player Name Header").GetComponent<TextMeshProUGUI>();
        playerScore = gameObject.transform.Find("Player Score Header").GetComponent<TextMeshProUGUI>();

        playerPlace.text = "23";
        playerName.text = "Nikita";
        playerScore.text = "99";
    }
}
