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
    private Score score;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        rb.velocity = shootDirection.normalized * speed;
        Destroy(gameObject, lifeTime);

        score = FindAnyObjectByType<Score>();
        if (score == null)
        {
            Debug.LogWarning("Score script not found in the scene.");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy")
        {
            if (score != null)
            {
                score.AddEnemyScore();

                Destroy(other.gameObject);
            }
        }
        else if (other.collider.CompareTag("Asteroid"))
        {
            if (score != null)
            {
                score.AddAsteroidScore();
            }
        }

            if (impactEffect != null)
        {
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject;
            Destroy(effect, 5f);
        }

        Destroy(gameObject);
    }
}
