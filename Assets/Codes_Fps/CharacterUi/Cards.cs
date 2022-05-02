using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Card",menuName="Card")]
public class Cards : ScriptableObject
{
    public string playerName;
    public string GunName;
    public Sprite characterSprite;
    public Sprite gunSprite;
    public float health;
    public float speed;
    public float JumpSpeed;
    public float fastSpeed;
    public GameObject CharacterCanvas;
    public void start()
    {
        
    }
}
