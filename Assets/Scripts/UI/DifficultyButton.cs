using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button _difficultyButton;

    private GameManager _gameManager;

    public float difficulty;

    public string difficultyName;

    void Start()
    {
        _difficultyButton = gameObject.GetComponent<Button>();
        _difficultyButton.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    
    void SetDifficulty()
    {
        _gameManager.difficultyName = difficultyName;
        _gameManager.StartGame(difficulty);
    }
}
