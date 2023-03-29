using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEntry
{
    public string playerName;
    public int playerScore;
    
    [Serializable]
    public class Leaderboard
    {
        public string playerName;
        public string currentPlayerName;
        public string bestPlayerName;
        
        public int playerScore;
        public int currentPlayerScore;
        public int bestPlayerScore;

    }
    public InputEntry(string name, int score)
    {
        playerName = name;
        this.playerScore = score;
    }
}
