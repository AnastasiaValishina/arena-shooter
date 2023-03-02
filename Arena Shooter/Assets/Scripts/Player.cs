using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkingSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float jumpDuration;

    float speed;
    float timeSinceLastJump = Mathf.Infinity;
    void Start()
    {

    }

    void Update()
    {
        MoveLeftAndRight();

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

    private void MoveLeftAndRight()
    {
        float vert = Input.GetAxis("Vertical") * speed;
        float hor = Input.GetAxis("Horizontal") * speed;

        vert *= Time.deltaTime;
        hor *= Time.deltaTime;

        transform.Translate(0, vert, 0);
        transform.Translate(hor, 0, 0);
    }
}
