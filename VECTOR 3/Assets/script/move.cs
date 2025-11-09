using UnityEngine;

public class jumpg : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 5.0f;
    public Animator animatorl;
    public bool isGround;
    public float rayDistance = 0.6f;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = true;
            animatorl.SetBool("jumping", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false;
            animatorl.SetBool("jumping", false);
        }
    }
    

    void Update()
     {


        if (Input.GetKeyDown(KeyCode.Space) && isGround )
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}