using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button difficultyButton;

    private GameManager gameManager;

    public float difficulty;

    public string difficultyName;
    // Start is called before the first frame update
    void Start()
    {
        difficultyButton = gameObject.GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void SetDifficulty()
    {
        Debug.Log($"You pushed {gameObject.name} button!");
        gameManager.difficultyName = difficultyName; 
        gameManager.StartGame(difficulty);
    }
}
