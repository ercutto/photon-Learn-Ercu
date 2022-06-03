
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviourPunCallbacks
{
    public Cards Cards;
    public GunsStat guns;
    public string playerName;
    //gun
    public string GunName;
    public float GunReloadTime;
    public int gunCapacity;
    public float gunRange;
    public float gunRepeatTime;
    public GameObject gunPrefab;

    public GameObject [] myGuns;
    public Transform RigthHandGunHolder;
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

    public Image Indicator, NameBar;
    public int myTeam;
    public Text myIdtext;
    public bool _blueteam;
    private InstatiateExample instatiateExample;
    public Vector3 startPos;
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
        playerName = MasterManager.GameSettings.NickName;
        //GunName = Cards.GunName;
        health = Cards.health;
        speed = Cards.speed;
        jumpSpeed = Cards.JumpSpeed;
        nameArea.text = playerName;
        speedArea.text = Cards.speed.ToString();
        healthArea.text = Cards.health.ToString();
        characterSprite.sprite = Cards.characterSprite;
        //gunSprite.sprite = Cards.gunSprite;
        GunName = guns.gunName;
        gunSprite.sprite = guns.gunsSprite;
        gunCapacity = guns.capacity;
        gunPrefab = guns.gunPrefab;
        gunRange = guns.range;
        gunRepeatTime = guns.repeatTime;
        GunReloadTime = guns.repeatTime;
        
        
        Debug.Log(string.Format
            ("PLAYER: {0} | GUN: {1} | HEALTH: {2} | SPEED: {3} | JUMP: {4}  ",
            playerName, GunName, health, speed, jumpSpeed));
        //Application.targetFrameRate = 60;
        _isGrounded = GetComponent<PhysicsCont>().isGrounded;
        _isWalking = GetComponent<Move>().isWalking;
        animator = GetComponent<Animator>();
        //Selected Gun
        //GameObject selectedGun=PhotonNetwork.Instantiate(gunPrefab.name, RigthHandGunHolder.position, RigthHandGunHolder.rotation);
        //GameObject selectedGun = MasterManager.NetworkInstantiate(gunPrefab, RigthHandGunHolder.position, RigthHandGunHolder.rotation);
        //selectedGun.transform.SetParent(RigthHandGunHolder);
        for (int i = 0; i < myGuns.Length; i++)
        {
            if (myGuns[i].name != GunName) { myGuns[i].SetActive(false); } else
            {
                myGuns[i].SetActive(true);
            }
        }
        instatiateExample = GameObject.Find("Instantiation").GetComponent<InstatiateExample>();

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        _isGrounded = GetComponent<PhysicsCont>().isGrounded;
        _isWalking = GetComponent<Move>().isWalking;
        if (_isGrounded && _isWalking)
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
            if (current == 0)
            {
                //Destroy(gameObject);
                transform.position = startPos;
                if (myTeam == 1)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                    instatiateExample.Respawnblue();
                }
                else
                {
                    PhotonNetwork.Destroy(this.gameObject);
                    instatiateExample.RespawnRed();
                }

            }
        }

    }
   

   


}
