using Arena.HeroAttributes;
using UnityEngine;

namespace Arena.Combat
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] Transform rotatePoint;
        [SerializeField] Bullet bulletPrefab;
        [SerializeField] float bulletSpeed;
        [SerializeField] Transform gun;
        [SerializeField] float timeBetweenFiring;

        Camera mainCam;
        float timer;
        PlayerController controller;

        private void Awake()
        {
            controller = GetComponent<PlayerController>();
        }
        private void Start()
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
        void Update()
        {            
            Vector3 rotation = GetMousePosition() - rotatePoint.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            rotatePoint.rotation = Quaternion.Euler(0, 0, rotZ);

            timer += Time.deltaTime;

            if (controller.IsJumping) return;

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
