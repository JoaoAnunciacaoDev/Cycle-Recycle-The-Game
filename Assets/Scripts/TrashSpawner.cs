using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private Trash trashPrefab;
    [SerializeField] private float initialSpawnInterval = 2f;
    [SerializeField] private float minimumSpawnInterval = 0.5f;
    [SerializeField] private float difficultyIncreaseTime = 30f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        float spawnInterval = GetSpawnInterval();

        if (timer < spawnInterval) return;

        SpawnTrash();
        timer -= spawnInterval;
    }

    private void SpawnTrash()
    {
        Instantiate(
            trashPrefab,
            transform.position,
            Quaternion.identity
        );
    }

    private float GetSpawnInterval()
    {
        float progress = Mathf.Clamp01(gameTimer.ElapsedTime / difficultyIncreaseTime);

        return Mathf.Lerp(
            initialSpawnInterval,
            minimumSpawnInterval,
            progress
        );
    }
}
