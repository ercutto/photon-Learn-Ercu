using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Cards cards;
    public float maxHealth;
    public float currentHealth;
    private Players players;
    

    void Start()
    {
        if (!cards) { cards = GetComponent<Players>().Cards; }
        
        players = GetComponent<Players>();
        maxHealth = cards.health;
        currentHealth = maxHealth;
        
    }


    void Update()
    {

    }
    public void Damage(float damage)
    {

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        else if (currentHealth - damage <= 0)
        {
            currentHealth = 0f;
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
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        players.currentHealthHandler(currentHealth);
       

    }
}
