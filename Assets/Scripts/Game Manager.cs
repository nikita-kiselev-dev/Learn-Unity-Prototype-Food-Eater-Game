using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public List<GameObject> targetsPremium;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject scoreTextObj;
    public Button exitButton;
    private int difficultyScoreBonus;
    private int mediumScoreBonus = 2;
    private int hardScoreBonus = 4;
    public string difficultyName;
    public Slider volumeSlider;

    public AudioSource buttonSound;

    public TextMeshProUGUI livesText;
    private uint currentLives;

    private int foodCount;
    public TextMeshProUGUI foodCountText;
    private int foodPremiumDivider = 10;
    
    public GameObject pauseScreen;
    private bool pauseEnabled;

    public GameObject startSpawn;
    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
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
            if (foodCount % foodPremiumDivider == 0 && foodCount != 0)
            {
                int index = Random.Range(0, targetsPremium.Count);
                Instantiate(targetsPremium[index]);
                foodCount++;
                foodCountText.text = $"Food: {foodCount}";
            }
            else
            {
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
                if (targets[index].CompareTag("Good"))
                {
                    foodCount++;
                    foodCountText.text = $"Food: {foodCount}";
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
        }
        livesText.text = $"Lives: {currentLives}";
        if (!(currentLives > 0))
        {
            GameOver();
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
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
}
