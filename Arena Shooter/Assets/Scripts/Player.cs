using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkingSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float jumpDuration;

    float speed;
    float timeSinceLastJump = Mathf.Infinity;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
        MoveControl();
        FlipSprite();
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            speed = jumpSpeed;
        }

        if (jumpDuration < timeSinceLastJump)
        {
            timeSinceLastJump = 0;
            speed = walkingSpeed;
        }
        timeSinceLastJump += Time.deltaTime;
    }

    void MoveControl()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveHorizontal, moveVertical) * speed;
        rb.position = new Vector3(rb.position.x, rb.position.y);
      
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
}
