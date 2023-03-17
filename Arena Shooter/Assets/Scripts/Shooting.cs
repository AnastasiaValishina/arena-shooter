using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] float bulletSpeed;

    Camera mainCam;
    public Transform gun;
    public bool canFire;
    float timer;
    public float timeBetweenFiring;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        Vector3 rotation = GetMousePosition() - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        }
    }

    private Vector3 GetMousePosition()
    {
        return mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
