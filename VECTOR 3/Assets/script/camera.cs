using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    public float rollSpeed = 8f;          // Скорость переката
    public float rollDuration = 0.3f;     // Длительность переката
    public float rollCooldown = 0.8f;     // Перезарядка переката
    public bool isGround;
    private bool isRolling = false;
    private bool canRoll = true;
    private bool but = false;
    private Rigidbody2D rb;
    private Animator anim;

    private BoxCollider2D boxCollider;
    // Направление, куда игрок "смотрит" (например, последняя ось движения)
    private Vector2 lookDirection = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false;
          
        }
    }

    void Update()
    {
        if (isRolling) return;
        

        // Обновляем направление взгляда, если игрок двигается
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveInput != Vector2.zero)
            lookDirection = moveInput.normalized;

        // Проверяем нажатие Shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && canRoll && isGround)
        {
            StartCoroutine("Roll");
            but = true;
            anim.SetBool("Rool", true);
            boxCollider.size = new Vector2(0.36f, 0.35f);
            boxCollider.offset = new Vector2(0f, -0.02f);

        }
        else
        {
            but = false;
            anim.SetBool("Rool", false);
            boxCollider.size = new Vector2(0.36f, 0.68f);
            boxCollider.offset = new Vector2(0f, 0f);
        }
    }

    private System.Collections.IEnumerator Roll()
    {
        canRoll = false;
        isRolling = true;

        if (anim != null)
            anim.SetTrigger("Rool");

        float startTime = Time.time;

        // Движение во время переката
        while (Time.time < startTime + rollDuration)
        {
            rb.linearVelocity = lookDirection * rollSpeed;
            yield return null;
        }

        rb.linearVelocity = Vector2.zero;
        isRolling = false;

        yield return new WaitForSeconds(rollCooldown);
        canRoll = true;
    }
}
