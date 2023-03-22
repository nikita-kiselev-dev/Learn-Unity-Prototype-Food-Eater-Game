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
    private int score;
    
    [SerializeField] private HeartLivesManager heartIconGroup;
    public int currentLives { get; private set; }
    public TextMeshProUGUI livesText;

    public TextMeshProUGUI gameOverText;

    private float spawnRate = 1.0f;
    public GameObject startSpawn;
    public bool isGameActive;
    public Button restartButton;
    public Button exitButton;
    public GameObject titleScreen;

    private int difficultyScoreBonus;
    private int mediumScoreBonus = 2;
    private int hardScoreBonus = 4;
    public string difficultyName;

    public Slider volumeSlider;

    private int foodCount;
    public TextMeshProUGUI foodCountText;
    private int foodPremiumDivider = 10;

    public GameObject pauseScreen;
    private bool pauseEnabled;

    [SerializeField] private bool isFoodSpawned;

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMode(pauseEnabled);
            pauseEnabled = !pauseEnabled;
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Destroy(startSpawn);
            switch (SpawnRandomizer())
            {
                case true:
                {
                    if (foodCount % foodPremiumDivider == 0 && foodCount != 0)
                    {
                        int index = Random.Range(0, premiumTargets.Count);
                        Instantiate(premiumTargets[index]);
                        foodCount++;
                        foodCountText.text = $"Food: {foodCount}";
                    }
                    else
                    {
                        int index = Random.Range(0, foodTargets.Count);
                        Instantiate(foodTargets[index]);
                        foodCount++;
                        foodCountText.text = $"Food: {foodCount}";
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

    public void UpdateScore(int scoreToAdd)
    {
        switch (difficultyName)
        {
            case ("easy"):
                difficultyScoreBonus = 0;
                break;
            case ("medium"):
                difficultyScoreBonus = mediumScoreBonus;
                break;
            case ("hard"):
                difficultyScoreBonus = hardScoreBonus;
                break;
        }

        score += scoreToAdd + difficultyScoreBonus;
        scoreText.text = $"Score: {score}";
    }

    public void StartGame(float difficulty)
    {
        heartIconGroup.gameObject.SetActive(true);
        volumeSlider.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget());

        spawnRate /= difficulty;

        scoreTextObj.gameObject.SetActive(true);
        score = 0;
        scoreText.text = $"Score: {score}";

        livesText.gameObject.SetActive(true);
        currentLives = 3;
        livesText.text = $"Lives: {currentLives}";

        foodCountText.gameObject.SetActive(true);
        foodCount = 0;
        foodCountText.text = $"Food: {foodCount}";
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void LooseLive()
    {
        if (currentLives > 0)
        {
            currentLives--;
            heartIconGroup.DestroyHeartIcons();
        }

        livesText.text = $"Lives: {currentLives}";
        if (!(currentLives > 0))
        {
            GameOver();
        }
    }

    public void ExitGame()
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

}

