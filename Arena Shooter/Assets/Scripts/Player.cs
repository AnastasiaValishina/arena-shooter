using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkingSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float jumpDuration;

    float speed;
    float timeSinceJumpStarted = Mathf.Infinity;
    Animator animator;

    Rigidbody2D rb;
    void Start()
    {
        speed = walkingSpeed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Jump();
        FlipSprite();
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            speed = jumpSpeed;
        }

        if (jumpDuration < timeSinceJumpStarted)
        {
            timeSinceJumpStarted = 0;
            speed = walkingSpeed;
        }
        timeSinceJumpStarted += Time.deltaTime;
    }

    void Run()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveHorizontal, moveVertical) * speed;

        animator.SetBool("isRunning", HasSpeed(rb.velocity.x) || HasSpeed(rb.velocity.y));
    }

    void FlipSprite()
    {
        if (HasSpeed(rb.velocity.x))
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    private bool HasSpeed(float pos)
    {
        return Mathf.Abs(pos) > Mathf.Epsilon;
    }
}
