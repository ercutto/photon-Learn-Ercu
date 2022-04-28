using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float damageMultiplier;
    private float bulletdamage;
    private float damageEffectsValue;
    public GameObject Player;
    public PlayerColliders playerColliders;
    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.parent.gameObject;
        playerColliders=Player.GetComponent<PlayerColliders>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="bullet")
        {
            bulletdamage = other.gameObject.GetComponent<BulletMove>().damageValue;
            damageEffectsValue=bulletdamage* damageMultiplier;
            playerColliders.Damage(damageEffectsValue);
        }
    }
}
