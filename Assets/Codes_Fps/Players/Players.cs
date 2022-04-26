using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players:MonoBehaviour  
{
    public Cards Cards;
    public string playerName;
    public string GunName;
    public Sprite characterSprite;
    public Sprite gunSprite;
    public float health;
    public float speed;
    public float jumpSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        playerName = Cards.playerName;
        GunName = Cards.GunName;
        health = Cards.health;
        speed = Cards.speed;
        jumpSpeed = Cards.JumpSpeed;
        Debug.Log(string.Format
            ("PLAYER: {0} | GUN: {1} | HEALTH: {2} | SPEED: {3} | JUMP: {4}  ",
            playerName, GunName, health, speed, jumpSpeed));
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
