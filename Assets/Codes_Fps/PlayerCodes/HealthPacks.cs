using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPacks : MonoBehaviour
{
    float healtvalue = 50;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.GetComponent<PlayerColliders>() != null)
        {
            PlayerColliders currentPlayer = other.gameObject.GetComponent<PlayerColliders>();
            float maxHealth = currentPlayer.maxHealth;
            float PlayerCurrentHealth = currentPlayer.currentHealth;
            if (PlayerCurrentHealth >= maxHealth)
            { 
                Debug.Log(healtvalue);

            }
            else
            {
                currentPlayer.Heal(healtvalue);
                this.gameObject.SetActive(false);
            }
        }
    }
}
