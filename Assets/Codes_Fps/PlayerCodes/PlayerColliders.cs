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
        cards = GetComponent<Players>().Cards;
        players = GetComponent<Players>();
        maxHealth = cards.health;
        currentHealth = maxHealth;
    }

   
    void Update()
    {
        
    }
    public void Damage(float damage)
    {
        if (currentHealth<=0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }
        
        players.currentHealthHandler(currentHealth);
        Debug.Log(currentHealth);
        
    }
    public void Heal(float heal)
    {
        currentHealth += heal;
        if (currentHealth>=maxHealth)
        {
            currentHealth = maxHealth;
        }
        

        players.currentHealthHandler(currentHealth);
    }
}
