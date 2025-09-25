using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.22f, 0.22f, 1f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.22f, 0.22f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded);
    }
    private void jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
