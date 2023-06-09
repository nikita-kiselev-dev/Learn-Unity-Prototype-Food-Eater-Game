using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> foodTargets;
    [SerializeField] private List<GameObject> enemyTargets;
    [SerializeField] private List<GameObject> premiumTargets;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreTextObj;

    [SerializeField] private GameSaver gameSaver;

    [SerializeField] private InputController inputController;
    
    private string playerName;
    private int playerScore;
    
    [SerializeField] private HeartLivesManager heartIconGroup;
    public int CurrentLives { get; private set; }
    public TextMeshProUGUI livesText;

    public TextMeshProUGUI gameOverText;

    private float _spawnRate = 1.0f;
    public GameObject startSpawn;
    public bool isGameActive;
    public Button restartButton;
    public Button exitButton;
    public GameObject titleScreen;

    private int _difficultyScoreBonus;
    private const int _mediumScoreBonus = 2;
    private const int _hardScoreBonus = 4;
    public string difficultyName;

    public Slider volumeSlider;

    private int _foodCount;
    public TextMeshProUGUI foodCountText;
    private const int _foodPremiumDivider = 10;

    public GameObject pauseScreen;
    private bool _pauseEnabled;

    [SerializeField] private bool isFoodSpawned;

    [SerializeField] private Leaderboard leaderboard;

    void Awake()
    {
        leaderboard.ArrayInitialization();
        gameSaver.LoadPlayerData();
        leaderboard.playerName = gameSaver.playerName;
        leaderboard.playerScore = gameSaver.playerScore;
        exitButton.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMode(_pauseEnabled);
            _pauseEnabled = !_pauseEnabled;
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            ChooseTargetToSpawn();
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        switch (difficultyName)
        {
            case ("easy"):
                _difficultyScoreBonus = 0;
                break;
            case ("medium"):
                _difficultyScoreBonus = _mediumScoreBonus;
                break;
            case ("hard"):
                _difficultyScoreBonus = _hardScoreBonus;
                break;
        }

        playerScore += scoreToAdd + _difficultyScoreBonus;
        scoreText.text = $"Score: {playerScore}";
    }

    public void StartGame(float difficulty)
    {
        leaderboard.playerName = inputController.GetPlayerName();
        gameSaver.SavePlayerData();
        heartIconGroup.gameObject.SetActive(true);
        volumeSlider.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        scoreTextObj.gameObject.SetActive(true);
        livesText.gameObject.SetActive(true);
        foodCountText.gameObject.SetActive(true);
        
        isGameActive = true;
        
        Destroy(startSpawn);
        
        StartCoroutine(SpawnTarget());

        _spawnRate /= difficulty;
        
        playerScore = 0;
        scoreText.text = $"Score: {playerScore}";
        
        CurrentLives = 3;
        livesText.text = $"Lives: {CurrentLives}";
        
        _foodCount = 0;
        foodCountText.text = $"Food: {_foodCount}";
    }

    private void GameOver()
    {
        leaderboard.playerScore = playerScore;
        leaderboard.AddPlayerToLeaderboard();
        Debug.Log("GameOver!");
        leaderboard.BubbleSortByScore();
        gameSaver.SavePlayerData();
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void LooseLive()
    {
        if (CurrentLives > 0)
        {
            CurrentLives--;
            heartIconGroup.DestroyHeartIcons();
        }

        livesText.text = $"Lives: {CurrentLives}";
        if (!(CurrentLives > 0))
        {
            GameOver();
        }
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PauseMode(bool pauseEnabled)
    {
        switch (pauseEnabled)
        {
            case true:
                Time.timeScale = 1.0f;
                pauseScreen.gameObject.SetActive(false);
                break;
            case false:
                Time.timeScale = 0.0f;
                pauseScreen.gameObject.SetActive(true);
                break;
        }
    }

    private bool SpawnRandomizer()
    {
        int index = Random.Range(0, 11);
        switch (index)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                return true;
            case 8:
            case 9:
            case 10:
                return false;
        }

        return false;
    }

    private void ChooseTargetToSpawn()
    {
        switch (SpawnRandomizer())
        {
            case true:
            {
                if (_foodCount % _foodPremiumDivider == 0 && _foodCount != 0)
                {
                    int index = Random.Range(0, premiumTargets.Count);
                    Instantiate(premiumTargets[index]);
                    _foodCount++;
                    foodCountText.text = $"Food: {_foodCount}";
                }
                else
                {
                    int index = Random.Range(0, foodTargets.Count);
                    Instantiate(foodTargets[index]);
                    _foodCount++;
                    foodCountText.text = $"Food: {_foodCount}";
                }
                break;
            }
            case false:
            {
                int index = Random.Range(0, enemyTargets.Count);
                Instantiate(enemyTargets[index]);
                break;
            }
        }
    }

}

