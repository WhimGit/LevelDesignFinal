using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{
    public int health;
    public Slider healthbar;
    public Text healthText;
    public GameObject gameOver;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    void Update()
    {
        healthbar.value = health;
        healthText.text = "" + health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            health -= 5;
        }
        else if (other.CompareTag("Boss"))
        {
            health -= 20;
        }
        if (health <= 0)
        {
            Time.timeScale = 0;
            canvas.SetActive(false);
            gameOver.SetActive(true);
        }
    }
}
