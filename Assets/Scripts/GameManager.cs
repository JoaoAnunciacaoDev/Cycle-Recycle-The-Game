using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private TMPro.TextMeshProUGUI finalTimeLabel;
    [SerializeField] private TMPro.TextMeshProUGUI finalScoreLabel;
    [SerializeField] private int maxLives = 3;

    public int currentLives { get; private set; }
    public int currentScore {get; private set;}

    private void Awake()
    {
        currentLives = maxLives;
        currentScore = 0;
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }

    public void TakeDamage(int damage)
    {
        currentLives = Mathf.Max(currentLives - damage, 0);

        if (currentLives == 0)
            GameOver();
    }

    private void GameOver()
    {
        finalTimeLabel.text = $"Time: {gameTimer.ElapsedTime:0.00}s";
        finalScoreLabel.text = $"Score: {currentScore}";
        gameOverPanel.SetActive(true);
    }
}
