
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Players : MonoBehaviourPunCallbacks, IPunObservable
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
    public float currentHealth;
    public Text[] publicHealth;
    public GameObject[] Other;
    public GameObject playerHolder;
    
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
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            Debug.Log(p.transform.position);
        }
        if (myTeam == 1)
        {
            PhotonNetwork.LocalPlayer.JoinTeam("Blue");
           
        }
        else
        {
            PhotonNetwork.LocalPlayer.JoinTeam("Red");
            Debug.Log(PhotonNetwork.LocalPlayer.GetPhotonTeam());
        }
        if (PhotonNetwork.LocalPlayer.GetPhotonTeam() != null)
        {
            Debug.Log(PhotonNetwork.LocalPlayer.GetPhotonTeam().Name);
        }
        //photonView.RPC("SendHealth", RpcTarget.OthersBuffered);
        //Other = GameObject.FindGameObjectsWithTag("Player");
        //foreach (var otherplayer in Other)
        //{
        //    if (otherplayer.GetPhotonView() != this.photonView)
        //    {

        //        if (otherplayer.GetComponent<Players>() != null)
        //        {
        //            for (int i = 0; i < Other.Length; i++)
        //            {

        //                Debug.Log(Other[i].name + "listede");
        //                Other[i].GetComponent<Players>().publicHealth[i].text = currentHealth.ToString();


        //            }




        //            //for (int i = 0; i < publicHealth.Length; i++)
        //            //{
        //            //    otherplayer.GetComponent<Players>().publicHealth[i].text = othershealth.ToString();
        //            //}

        //        }
        //    }
        //}
        photonView.RPC("SendHealth", RpcTarget.AllViaServer, health);
        //viewId = this.gameObject.GetComponent<PhotonView>().ViewID;
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

        if (Input.GetKeyDown(KeyCode.O))
        {
            LeaveRoom();
        }
        //photonView.RPC("SendHealth", RpcTarget.OthersBuffered, currentHealth);

    }

    public void currentHealthHandler(float current)
    {

       
        
        if (current >= 0)
        {

          
            if (current == 0)
            {
               
                //Destroy(gameObject);

                //if (myTeam == 1)
                //{
                //PhotonNetwork.Destroy(this.gameObject);


                //instatiateExample.Respawnblue();

                //}
                //else
                //{

                //    //PhotonNetwork.Destroy(this.gameObject);
                //    //instatiateExample.RespawnRed();


                //}
               
                photonView.RPC("MoveToStartPos", RpcTarget.AllViaServer);
                
                photonView.RPC("SendHealth", RpcTarget.AllViaServer,currentHealth);
            }
            
        }

        currentHealth = current;
        healthArea.text = current.ToString();
        photonView.RPC("SendHealth", RpcTarget.AllViaServer,currentHealth);
       
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            stream.SendNext(playerName);
            stream.SendNext(currentHealth);
            stream.SendNext(health);

        }
        else
        {

            playerName = (string)stream.ReceiveNext();
            currentHealth = (float)stream.ReceiveNext();
            health = (float)stream.ReceiveNext();

        }
    }
    [PunRPC]
    void SendHealth(float othershealth)
    {

        //////publicHealth.text = othershealth.ToString();
        Other = GameObject.FindGameObjectsWithTag("Player");
        foreach (var otherplayer in Other)
        {
            if (otherplayer.GetPhotonView() != this.photonView)
            {

                if (otherplayer.GetComponent<Players>() != null)
                {
                    for (int i = 0; i < Other.Length; i++)
                    {

                    if (Other[i].GetComponent<PhotonView>().ViewID == this.gameObject.GetComponent<PhotonView>().ViewID)
                    {
                        Other[0].GetComponent<Players>().publicHealth[i].text = othershealth.ToString()+" :"+ Other[i].GetComponent<PhotonView>().Owner.NickName;
                    }

                    }

                }
            }
        }

    }
    public void PlayerDeath()
    {
        photonView.RPC("MoveToStartPos", RpcTarget.AllViaServer);
    }

    [PunRPC]
    void MoveToStartPos()
    {
        playerHolder.SetActive(false);
        transform.position = startPos;
        playerHolder.SetActive(true);
       

    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerHolder.activeSelf);
        }
        else
        {
            playerHolder.SetActive((bool)stream.ReceiveNext());
        }
    }

    public void OnClick_LeaveRoom()
    {
        LeaveRoom();
        
    }
    public void LeaveRoom()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PhotonNetwork.LeaveRoom();
        OnLeftRoom();
    }

    public override void OnLeftRoom()
    {
        
        
        SceneManager.LoadScene(0);
        base.OnLeftRoom();
    }
   
}
