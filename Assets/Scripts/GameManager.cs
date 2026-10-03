using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        Debug.Log("Score: " + currentScore);
    }

    public void TakeDamage(int damage)
    {
        currentLives = Mathf.Max(currentLives - damage, 0);
        Debug.Log("Damage, lives: " + currentLives);

        if (currentLives == 0)
            GameOver();
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
