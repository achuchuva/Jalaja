using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laserPrefab;
    private PlayerControls input = null;
    private PlayerMovement playerMovement;
    public float laserSpeed = 10f;
    public float laserLifetime = 5f;
    public Transform[] firePoints;

    void Start()
    {
        input = new PlayerControls();
        input.Enable();

        input.Player.Shoot.performed += ctx => Fire();
        playerMovement = GetComponent<PlayerMovement>();

    }

    void Fire()
    {
        Vector2 shootDirection = playerMovement.GetShootDirection();

        foreach (Transform firePoint in firePoints)
        {
            Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, shootDirection);
            GameObject laser = Instantiate(laserPrefab, firePoint.position, spawnRotation);
            laser.GetComponent<Laser>().shootDirection = shootDirection;
        }

        //Rigidbody2D laserRB = laser.GetComponent<Rigidbody2D>();
        //if (laserRB == null)
        //{
        //    laserRB = laser.AddComponent<Rigidbody2D>();
        //}

        //Destroy(laser, laserLifetime);
    }
}
