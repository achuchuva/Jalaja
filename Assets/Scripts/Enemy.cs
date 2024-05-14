using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

        transform.right = player.position - transform.position;

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
            Shoot();
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

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Vector3 relativePos = player.position - transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
