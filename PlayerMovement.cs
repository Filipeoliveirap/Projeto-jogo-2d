public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }

    private void HandleJump()
    {
        // Verifica se o jogador apertou o botão de pulo e se está no chão
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;  // Impede pular novamente até estar no chão
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Marca o jogador como no chão
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();  // Notifica o GameManager se colidir com obstáculo
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // Garante que o jogador esteja no chão durante o contato
        }
    }

    private void OnCollisionExit2D(Collision2D collision)  // Corrigido o nome do método
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;  // Marca o jogador como fora do chão quando sair do contato
        }
    }
}
