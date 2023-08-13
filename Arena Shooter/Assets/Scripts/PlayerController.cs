using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpDuration;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float speed;

    Animator animator;
    Camera mainCam;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Run();
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Jump());
        }
        FlipSprite();
    }

    public void PlayHitAnimation()
    {
        animator.SetTrigger("hit");
    }

    IEnumerator Jump()
    {
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        float timeElapsed = 0;

        while (timeElapsed < jumpDuration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / jumpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    void Run()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementDirection = Vector2.ClampMagnitude(movementDirection, 1);
        transform.Translate(movementDirection * speed * Time.deltaTime);

        animator.SetBool("isRunning", HasSpeed(rb.velocity.x) || HasSpeed(rb.velocity.y));
    }

    void FlipSprite()
    {
        if (HasSpeed(rb.velocity.x))
        {
            sprite.transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    private bool HasSpeed(float pos)
    {
        return Mathf.Abs(pos) > Mathf.Epsilon;
    }
}
