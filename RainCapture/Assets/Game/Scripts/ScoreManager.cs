using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // For reloading the scene

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject tryAgainButton; // Try Again button
    public FishSpawner fishSpawner; // Reference to FishSpawner
    public int gameOverScore = -10;

    private bool isGameOver = false;

    void Start()
    {
        Debug.Log("ScoreManager initialized");
        UpdateUI();

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (tryAgainButton != null)
            tryAgainButton.SetActive(false); // Hide button at start
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        Debug.Log("Score changed by: " + amount + " | Current score: " + score);
        UpdateUI();

        if (score <= gameOverScore)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("Game Over!");
        if (gameOverText != null)
            gameOverText.SetActive(true);

        if (tryAgainButton != null)
            tryAgainButton.SetActive(true);

        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume normal game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }
}
