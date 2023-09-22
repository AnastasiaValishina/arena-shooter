using Arena.HeroStats;
using System.Collections;
using UnityEngine;

namespace Arena.HeroAttributes
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _jumpDuration;
        [SerializeField] SpriteRenderer sprite;
        
        public float JumpCooldownTimer { get; private set; } = 0f;
        public bool IsCooldown { get; private set; }
        public float JumpCooldownTime { get { return _jumpCooldownTime; } private set { } }
        public int JumpsLeft { get { return _jumpsLeft; } private set { } }
        public bool IsJumping { get; private set; }
        public int JumpsInRow { get; private set; }

        float _speed;
        Animator animator;
        Camera mainCam;
        Rigidbody2D rb;
        float _jumpCooldownTime;
        int _jumpsLeft;

        private void Awake()
        {
            _speed = GetComponent<BaseStats>().GetStat(HeroStat.MoveSpeed);
            _jumpCooldownTime = GetComponent<BaseStats>().GetStat(HeroStat.Cooldown);
            JumpsInRow = (int)GetComponent<BaseStats>().GetStat(HeroStat.JumpsInRow);
            _jumpsLeft = JumpsInRow;
        }

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
                if (IsJumping) return;
                if (_jumpsLeft <= 0 && IsCooldown) return;

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
            IsJumping = true;

            if (_jumpsLeft == JumpsInRow)
            {
                IsCooldown = true;
                JumpCooldownTimer = _jumpCooldownTime;
            }
            _jumpsLeft--;

            Vector2 startPosition = transform.position;
            Vector2 targetPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            float timeElapsed = 0;

            while (timeElapsed < _jumpDuration)
            {
                transform.position = Vector2.Lerp(startPosition, targetPosition, timeElapsed / _jumpDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            IsJumping = false;
        }

        void ApplyCooldown()
        {
            if (IsCooldown)
            {
                JumpCooldownTimer -= Time.deltaTime;

                if (JumpCooldownTimer < 0)
                {
                    IsCooldown = false;
                    _jumpsLeft = JumpsInRow;
                }
            }    
        }

        void Run()
        {
            Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movementDirection = Vector2.ClampMagnitude(movementDirection, 1);
            transform.Translate(movementDirection * _speed * Time.deltaTime);

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
