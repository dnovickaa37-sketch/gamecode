using Unity.VisualScripting;
using UnityEngine;


public class MainCh : MonoBehaviour
{
    [SerializeField] private float speedWalk = 3f;
    [SerializeField] private float speedRun = 5f;
    [SerializeField] private float jumpForce = 8f;
   
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();   
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                Move(speedRun);
            else Move(speedWalk);
        }
        else if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            Jump();
    }

    private void Move(float speed)
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.8f);
        isGrounded = collider.Length > 1;
    }
}
