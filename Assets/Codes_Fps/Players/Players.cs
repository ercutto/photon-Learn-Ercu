
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
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
    private bool _isGrounded;
    private bool _isWalking;
    private Animator animator;
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
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
            //Application.targetFrameRate = 60;

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
            _isGrounded = GetComponent<PhysicsCont>().isGrounded;
            _isWalking = GetComponent<Move>().isWalking;
            animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
 
            _isGrounded = GetComponent<PhysicsCont>().isGrounded;
            _isWalking = GetComponent<Move>().isWalking;
            if (_isGrounded&&_isWalking)
            {

                animator.SetBool("IsWalking", true);
            }

            else
            {
                animator.SetBool("IsWalking", false);
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

}
