using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeartLivesManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private GameObject heartIconGroup;
    private int currentLives;

    void Start()
    {
        currentLives = gameManager.currentLives;

    }

    public void DestroyHeartIcons()
    {
        currentLives = gameManager.currentLives;
        gameObject.transform.GetChild(currentLives).gameObject.SetActive(false);
    }
}
