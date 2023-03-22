using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeartLivesManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private int _currentLives;

    void Start()
    {
        _currentLives = gameManager.CurrentLives;

    }

    public void DestroyHeartIcons()
    {
        _currentLives = gameManager.CurrentLives;
        gameObject.transform.GetChild(_currentLives).gameObject.SetActive(false);
    }
}
