using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLives : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public GameObject gameOverMenu;
    public TextMeshProUGUI livesText;
    private Rigidbody2D rb;

    private void Start()
    {
        currentLives = maxLives;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            DecreaseLives();
        }
    }

    public void DecreaseLives(int amount = 1)
    {
        currentLives -= amount;

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            livesText.text = "x " + currentLives;
        }
    }

    public void IncreaseLives(int amount = 1)
    {
        currentLives += amount;
        currentLives = Mathf.Min(currentLives, maxLives);
    }

    private void GameOver()
    {
        gameOverMenu.SetActive(true);
        livesText.text = "x " + currentLives;
        Destroy(gameObject);
    }
}
