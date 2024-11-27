public class ObstacleMovement : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public float speed = 3f;

    private void Update()
    {
        MoveObstacle();
        CheckBounds();
    }

    private void MoveObstacle()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void CheckBounds()
    {
        if (transform.position.x < -10) // Saiu da tela
        {
            Destroy(gameObject);
        }
    }
}
