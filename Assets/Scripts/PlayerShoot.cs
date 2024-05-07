using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    private GameObject laser;
    private PlayerControls input = null;
    public GameObject Player_01_0;
    private PlayerMovement playerMovement;
    public float laserSpeed = 10f;
    public float laserLifetime = 5f;

    void Start()
    {
        input = new PlayerControls();
        input.Enable();

        input.Player.Shoot.performed += ctx => Fire();
        playerMovement = GetComponent<PlayerMovement>();

    }

    void Fire()
    {
        //Vector3 spawnPosition = new Vector3(0f, 2f, 0f); // change to player 1 location
        //Vector3 spawnPosition = Player_01_0.transform.position;
        //spawnPosition.y += 1f;
        Vector2 shootDirection = playerMovement.GetShootDirection();

        Vector3 spawnPosition = transform.position + (Vector3)shootDirection.normalized;

        Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, shootDirection);
        laser = Instantiate(prefabToInstantiate, spawnPosition, spawnRotation);

        laser.transform.SetParent(null);
        laser.SetActive(true);

        Rigidbody2D laserRB = laser.GetComponent<Rigidbody2D>();
        if (laserRB == null)
        {
            laserRB = laser.AddComponent<Rigidbody2D>();
        }

        laserRB.velocity = shootDirection.normalized * laserSpeed;

        laser.name = "laser";
        //laser.transform.SetParent(transform);
        Destroy(laser, laserLifetime);
    }
}
