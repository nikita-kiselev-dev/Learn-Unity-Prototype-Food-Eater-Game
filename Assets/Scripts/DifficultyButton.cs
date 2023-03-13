using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button difficultyButton;

    private GameManager gameManager;

    public float difficulty;

    public string difficultyName;

    void Start()
    {
        difficultyButton = gameObject.GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    
    void SetDifficulty()
    {
        gameManager.difficultyName = difficultyName; 
        gameManager.StartGame(difficulty);
    }
}
