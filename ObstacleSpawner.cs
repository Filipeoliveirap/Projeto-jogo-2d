public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(10, -2, 0);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
