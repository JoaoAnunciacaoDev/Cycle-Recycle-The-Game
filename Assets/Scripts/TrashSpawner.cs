using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Trash trashPrefab;
    [SerializeField] private TrashConfig trashConfig;
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

        TrashType randomType = GetRandomTrashType();

        trash.SetFallSpeed(GetRandomFallSpeed());
        trash.SetTrashType(randomType);
        trash.SetGameManager(gameManager);

        if (trashConfig != null)
        {
            trash.SetColor(trashConfig.GetColorForType(randomType));
        }
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

    private float GetRandomFallSpeed()
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

    private TrashType GetRandomTrashType()
    {
        return (TrashType)Random.Range(
            0,
            System.Enum.GetValues(typeof(TrashType)).Length
        );
    }
}
