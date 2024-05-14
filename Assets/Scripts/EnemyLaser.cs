using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public GameObject impactEffect;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            PlayerLives playerLives = other.gameObject.GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                playerLives.DecreaseLives(damage);
            }

            if (impactEffect != null)
            {
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
