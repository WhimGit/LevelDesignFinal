using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TeamIndex : sbyte
{
    None = -1,
    Neutral = 0,
    Player,
    Enemy,
    Count
}
public class TeamComponent : MonoBehaviour
{
    public GameObject nextLevelIntro;
    public GameObject enemies;
    public GameObject spawnPoint;
    public float maxHealth = 100;
    private float currentHealth;
    public TeamIndex _teamIndex = TeamIndex.None;
    public bool boss;
    private Rigidbody2D rb;
    public float knockback = -1f;
    public GameObject player;
    public GameObject canvas;

    public TeamIndex teamIndex
    {
        set
        {
            if (_teamIndex == value)
            {
                return;
            }
            _teamIndex = value;
        }
        get { return _teamIndex; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if(currentHealth <= 0)
        {
            if (!boss)
            {
                this.transform.position = spawnPoint.transform.position;
                currentHealth = maxHealth;
            }
            else
            { 
                nextLevelIntro.SetActive(true);
                enemies.SetActive(false);
                canvas.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }
    public void TakeDamage(float damageDone)
    {
        currentHealth -= damageDone;
        Vector2 difference = (transform.position - player.transform.position).normalized;
        Vector2 force = difference * knockback;
        rb.AddForce(force, ForceMode2D.Impulse);
        StartCoroutine(ResetKnockBack());
    }

    public IEnumerator ResetKnockBack()
    {
        yield return new WaitForSeconds(0.08f);
        rb.velocity = Vector3.zero;
    }
}
