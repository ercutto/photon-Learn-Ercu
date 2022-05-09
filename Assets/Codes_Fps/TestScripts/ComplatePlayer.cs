using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ComplatePlayer : MonoBehaviourPunCallbacks
{
    public Cards Cards;

    public string playerName;
    public string GunName;
    public Image characterSprite;
    public Image gunSprite;
    public float health;
    public float speed;
    public float fastSpeed;
    public float jumpSpeed;
    public TextMeshProUGUI nameArea;
    public TextMeshProUGUI healthArea;
    public TextMeshProUGUI speedArea;
    public GameObject profile;
    private bool _isGrounded;
    private bool _isWalking;
    public bool isFast;
    //Health
    public float maxHealth;
    public float currentHealth;
    //physics variables
    public Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;
    //end physics variables
    private CharacterController controller;
    private Animator animator;
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    #region Start And Update 
    void Start()
    {

        if (photonView.IsMine)
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
            //Application.targetFrameRate = 60;

            profile = Cards.CharacterCanvas;
            playerName = Cards.playerName;
            GunName = Cards.GunName;
            health = Cards.health;
            speed = Cards.speed;
            fastSpeed = Cards.fastSpeed;
            jumpSpeed = Cards.JumpSpeed;
            nameArea.text = Cards.playerName;
            speedArea.text = Cards.speed.ToString();
            healthArea.text = Cards.health.ToString();
            characterSprite.sprite = Cards.characterSprite;
            gunSprite.sprite = Cards.gunSprite;
            maxHealth = Cards.health;
            currentHealth = maxHealth;
            isFast = false;
            controller=GetComponent<CharacterController>();
           
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            PhysicsCheck();
           
            Move();
            AnimatorFunctions();
           


        }
    }
    #endregion   
    #region Animator
    void AnimatorFunctions()
    {
        if (_isGrounded && _isWalking)
        {

            animator.SetBool("IsWalking", true);
        }

        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    #endregion
    #region Move
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isFast = true;
        }
        else
        {
            isFast = false;
        }
        if (isFast)
        {
            controller.Move(fastSpeed * Time.deltaTime * move);

        }
        else
        {
            controller.Move(speed * Time.deltaTime * move);

        }
        if (x != 0 | y != 0)
        {
            _isWalking = true;
        }
        else
        {
            _isWalking = false;

        }
    }
    #endregion
    #region Physics Check
    void PhysicsCheck()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    #endregion
    #region Health
    public void Damage(float damage)
    {
        if (photonView.IsMine)
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth -= damage;
            }

            currentHealthHandler(currentHealth);
            Debug.Log(currentHealth);
        }




    }
    public void Heal(float heal)
    {
        if (photonView.IsMine)
        {
            currentHealth += heal;
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            currentHealthHandler(currentHealth);
        }
    }
    public void currentHealthHandler(float current)
    {

        healthArea.text = current.ToString();
        if (current >= 0)
        {

            Debug.Log(current + " Current health is zero!");

        }

    }
    #endregion
}
