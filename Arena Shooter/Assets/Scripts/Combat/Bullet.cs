using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;

    Camera mainCam;
    Rigidbody2D rb;
    public float force;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        
        Vector3 direction = GetMousePosition() - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        // bullet rotation
        // Vector3 rotation = transform.position - GetMousePosition();
        // float rot = Mathf.Atan2(rotation.y, rotation.y) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
    private Vector3 GetMousePosition()
    {
        return mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().DealDamage(damage);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
