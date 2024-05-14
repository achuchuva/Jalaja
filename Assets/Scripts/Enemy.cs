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
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        transform.right = player.position - transform.position + new Vector3(0f, 0f, 90f);

        if (Vector2.Distance(transform.position, player.position) < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.right = player.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance)
        {
            transform.position = this.transform.position;
        }

        if (nextFireTime <= 0)
        {
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            Debug.Log("Shooting bullet");
            nextFireTime = fireRate;
        }
        else
        {
            nextFireTime -= Time.deltaTime;
        }
        //if (Time.time >= nextFireTime)
        //{
        //    Shoot();
        //    nextFireTime = Time.time + 1f / fireRate; // Update next fire time
        //}
    }
    //void Shoot()
    //{
    //    GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
    //    Vector2 direction = (player.position - transform.position).normalized;
    //    newBullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    //}
}
