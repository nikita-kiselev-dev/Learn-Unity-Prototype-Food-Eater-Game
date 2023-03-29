using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputController : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameText;
    
    public string playerName;

    public bool isPlayerNameNull;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (String.IsNullOrEmpty(playerNameText.text))
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
}
