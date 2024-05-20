using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    private PlayerControls input = null;
    private PlayerMovement playerMovement;
    public float laserSpeed = 10f;
    public float laserLifetime = 5f;
    public Transform[] firePoints;
    public float fireCooldown = 0.5f;

    private float lastFireTime;

    void Start()
    {
        input = new PlayerControls();
        input.Enable();

        input.Player.Shoot.performed += ctx => Fire();
        playerMovement = GetComponent<PlayerMovement>();

        lastFireTime = -fireCooldown;
    }

    void Fire()
    {
        if (Time.time - lastFireTime >= fireCooldown)
        {
            Vector2 shootDirection = playerMovement.GetShootDirection();

            foreach (Transform firePoint in firePoints)
            {
                Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, shootDirection);
                GameObject laser = Instantiate(laserPrefab, firePoint.position, spawnRotation);
                laser.GetComponent<Laser>().shootDirection = shootDirection;
            }

            lastFireTime = Time.time;
        }
    }
}
