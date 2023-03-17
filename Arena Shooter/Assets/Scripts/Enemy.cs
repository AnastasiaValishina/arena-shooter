using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<Player>().transform;        
    }

    void Update()
    {
        if (target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
