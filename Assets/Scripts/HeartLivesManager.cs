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
        //FindHeartIcons();
    }

    private void FindHeartIcons()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void DestroyHeartIcons()
    {
        currentLives = gameManager.currentLives;
        Debug.Log("destroy heart");
        //gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.SetActive(false);
        gameObject.transform.GetChild(currentLives).gameObject.SetActive(false);
        Debug.Log(gameObject.transform.GetChild(currentLives));
    }
}
