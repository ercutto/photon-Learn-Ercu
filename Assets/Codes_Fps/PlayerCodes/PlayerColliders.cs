using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    public Cards cards;
    public float maxHealth;
    public float currentHealth;
    private Players players;
    
    void Start()
    {
        players = GetComponent<Players>();
        maxHealth = cards.health;
        currentHealth = maxHealth;
    }

   
    void Update()
    {
        
    }
    public void Damage(float damage)
    {
        currentHealth -= damage;
        players.currentHealthHandler(currentHealth);
        Debug.Log(currentHealth);
        
    }
}
