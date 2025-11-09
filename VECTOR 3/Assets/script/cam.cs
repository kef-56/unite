using UnityEngine;

public class cam : MonoBehaviour
{
    public float rollSpeed = 8f;          // Скорость переката
    public float rollDuration = 0.3f;     // Длительность переката
    public float rollCooldown = 0.8f;     // Перезарядка переката
   
    private bool isRolling = false;
    private bool canRoll = true;
  
    private Rigidbody2D rb;
    

    // Направление, куда игрок "смотрит" (например, последняя ось движения)
    private Vector2 lookDirection = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       

    }
   

    void Update()
    {
        if (isRolling) return;


        // Обновляем направление взгляда, если игрок двигается
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveInput != Vector2.zero)
            lookDirection = moveInput.normalized;

        // Проверяем нажатие Shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && canRoll)
        {
            StartCoroutine("Roll");
          

        }
       
    }

    private System.Collections.IEnumerator Roll()
    {
        canRoll = false;
        isRolling = true;

       

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
