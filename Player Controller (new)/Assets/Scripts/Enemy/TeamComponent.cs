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
    public float maxHealth = 100;
    private float currentHealth;
    public TeamIndex _teamIndex = TeamIndex.None;
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
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damageDone)
    {
        currentHealth -= damageDone;
    }

}
