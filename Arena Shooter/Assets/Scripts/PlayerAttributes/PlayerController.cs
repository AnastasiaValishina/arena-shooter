using System.Collections;
using UnityEngine;

namespace Arena.PlayerAttributes
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float jumpDuration;
        [SerializeField] float jumpCooldownTime;
        [SerializeField] SpriteRenderer sprite;
        [SerializeField] float speed;

        public float JumpCooldownTimer { get; private set; } = 0f;
        public bool IsCooldown { get; private set; }
        public float JumpCooldownTime { get { return jumpCooldownTime; } private set { } }

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
            FlipSprite();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsCooldown) return;
                StartCoroutine(Jump());
            }
            ApplyCooldown();
        }

        public void PlayHitAnimation()
        {
            animator.SetTrigger("hit");
        }

        IEnumerator Jump()
        {
            IsCooldown = true;
            JumpCooldownTimer = jumpCooldownTime;

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

        void ApplyCooldown()
        {
            if (IsCooldown)
            {
                JumpCooldownTimer -= Time.deltaTime;

                if (JumpCooldownTimer < 0)
                    IsCooldown = false;
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
}
