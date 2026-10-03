using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameTimer gameTimer;

    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI timeLabel;
    [SerializeField] private GameObject[] hearts;

    private void Update()
    {
        UpdateScore();
        UpdateTime();
        UpdateLives();
    }

    private void UpdateScore()
    {
        if (scoreLabel != null)
        {
            scoreLabel.text = $"{gameManager.currentScore}";
        }
    }

    private void UpdateTime()
    {
        if (timeLabel != null)
        {
            int minutes = Mathf.FloorToInt(gameTimer.ElapsedTime / 60f);
            int seconds = Mathf.FloorToInt(gameTimer.ElapsedTime % 60f);

            timeLabel.text = $"{minutes:00}:{seconds:00}";
        }
    }

    private void UpdateLives()
    {
        if (hearts != null)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (hearts[i] != null)
                {
                    hearts[i].SetActive(i < gameManager.currentLives);
                }
            }
        }
    }
}
