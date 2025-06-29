using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        ScoreManager.instantiate.AddScore(10);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
