using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Players:MonoBehaviour  
{
    public Cards Cards;
    

    public string playerName;
    public string GunName;
    public Image characterSprite;
    public Image gunSprite;
    public float health;
    public float speed;
    public float jumpSpeed;
    public TextMeshProUGUI nameArea;
    public TextMeshProUGUI healthArea;
    public TextMeshProUGUI speedArea;
    public GameObject profile;

    // Start is called before the first frame update
    void Start()
    {
        profile = Cards.CharacterCanvas;
        playerName = Cards.playerName;
        GunName = Cards.GunName;
        health = Cards.health;
        speed = Cards.speed;
        jumpSpeed = Cards.JumpSpeed;
        nameArea.text = Cards.playerName;
        speedArea.text = Cards.speed.ToString();
        healthArea.text = Cards.health.ToString();
        characterSprite.sprite = Cards.characterSprite;
        gunSprite.sprite = Cards.gunSprite;
        
        Debug.Log(string.Format
            ("PLAYER: {0} | GUN: {1} | HEALTH: {2} | SPEED: {3} | JUMP: {4}  ",
            playerName, GunName, health, speed, jumpSpeed));
        Application.targetFrameRate = 60;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void currentHealthHandler(float current)
    {
        healthArea.text = current.ToString();
    }
}
