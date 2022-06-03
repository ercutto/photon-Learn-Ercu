using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviourPunCallbacks
{
    public float damageMultiplier;
    private float bulletdamage;
    private float damageEffectsValue;
    public GameObject Player;
    public PlayerColliders playerColliders;
    public TeamViewer teamViewer;
    public int myTeam;
    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.parent.parent.gameObject;
        playerColliders=Player.GetComponent<PlayerColliders>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.gameObject.tag == "bullet")
            {
                if (other.gameObject.GetComponent<BulletMove>()!=null)
                {
                    BulletMove bulletMove = other.gameObject.GetComponent<BulletMove>();
                    int team = bulletMove.team;
                    if (team != myTeam)
                    {
                        bulletdamage = bulletMove.damageValue;
                        damageEffectsValue = bulletdamage * damageMultiplier;
                        playerColliders.Damage(damageEffectsValue);
                    }
                   
                }   
                
            }

        }
           
       
        
        
         
    }
}
