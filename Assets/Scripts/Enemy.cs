using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 3f;
    public float stoppingDistance = 20f;
    public float nearDistance = 5f;
    public float fireRate = 1f;
    private float nextFireTime;

    [Header("References")]
    public GameObject bullet;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance)
        {
            transform.position = this.transform.position;
        }

        if (nextFireTime <= 0)
        {
            // Instantiate(bullet, transform.position, Quaternion.identity);
            Debug.Log("Shooting bullet");
            nextFireTime = fireRate;
        }
        else
        {
            nextFireTime -= Time.deltaTime;
        }
    }
}
