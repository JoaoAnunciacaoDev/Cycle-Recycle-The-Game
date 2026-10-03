using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;

    public int currentLives { get; private set; }

    private void Awake()
    {
        currentLives = maxLives;
    }

    public void TakeDamage(int damage)
    {
        currentLives = Mathf.Max(currentLives - damage, 0);

        if (currentLives == 0)
            GameOver();
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
