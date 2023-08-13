using UnityEngine;

namespace Arena.Combat
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] Bullet bulletPrefab;
        [SerializeField] float bulletSpeed;
        [SerializeField] Transform gun;
        [SerializeField] float timeBetweenFiring;

        Camera mainCam;
        float timer;

        private void Start()
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
        void Update()
        {
            Vector3 rotation = GetMousePosition() - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);

            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                Instantiate(bulletPrefab, gun.position, Quaternion.identity);
                timer = 0;
            }
        }

        private Vector3 GetMousePosition()
        {
            return mainCam.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
