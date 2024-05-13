using UnityEngine;
using UnityEngine.UIElements;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public int damage = 1;
    public GameObject impactEffect;

    [HideInInspector]
    public Vector2 shootDirection;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        rb.velocity = shootDirection.normalized * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        // Check if the bullet hits something that has a Health component
        // Health enemy = hitInfo.GetComponent<Health>();
        // if (enemy != null)
        // {
        //     enemy.TakeDamage(damage);
        // }

        // Create an impact effect if specified
        // if (impactEffect != null)
        // {
        //     Instantiate(impactEffect, transform.position, transform.rotation);
        // }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
