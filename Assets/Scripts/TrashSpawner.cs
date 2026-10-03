using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private Trash trashPrefab;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float initialSpawnInterval = 2f;
    [SerializeField] private float minimumSpawnInterval = 0.5f;
    [SerializeField] private float difficultyIncreaseTime = 30f;
    [SerializeField] private float horizontalPadding = 0.5f;
    [SerializeField] private float initialFallSpeed = 3f;
    [SerializeField] private float maximumFallSpeed = 5f;

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
        float halfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float randomX = Random.Range(-halfWidth + horizontalPadding, halfWidth - horizontalPadding);

        Vector3 spawnPosition = new Vector3(
            randomX,
            transform.position.y,
            transform.position.z
        );

        Trash trash =Instantiate(
            trashPrefab,
            spawnPosition,
            Quaternion.identity
        );

        trash.SetFallSpeed(GetFallSpeed());
    }

    private float GetSpawnInterval()
    {
        float progress = Mathf.Clamp01(
            gameTimer.ElapsedTime / difficultyIncreaseTime
        );

        return Mathf.Lerp(
            initialSpawnInterval,
            minimumSpawnInterval,
            progress
        );
    }

    private float GetFallSpeed()
    {
        float progress = Mathf.Clamp01(
            gameTimer.ElapsedTime / difficultyIncreaseTime
        );

        return Mathf.Lerp(
            initialFallSpeed,
            maximumFallSpeed,
            progress
        );
    }
}
