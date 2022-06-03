using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeamViewer : MonoBehaviourPun
{
    public Image Indicator,NameBar;
    public int myTeam;
    public Text myIdtext;
    //public bool mycolor;
    
    private InstatiateExample Instantiator;

    // Start is called before the first frame update
    void Awake()
    {
        
        if (photonView.IsMine)
        {
            //photonView.RPC("RPC_GetTeam", RpcTarget.All);
            photonView.RPC("RPC_GetTeam", RpcTarget.MasterClient);
          

        }
    

    }
    public void Start()
    {
     
            
    }
    [PunRPC]
    void RPC_GetTeam()
    {
        // myTeam = MasterManager.nextPlayersTeam;
        //myTeam = InstatiateExample._myId;
        //InstatiateExample.UpdateTeam();
        //MasterManager.UpdateTeam();
        //if (MasterManager.nextPlayersTeam == 1)
        //{
        //    myIdtext.text = "Blue";
        //    Indicator.color = Color.blue;
        //    NameBar.color = Color.blue;
        //    GetComponent<Shoot>()._myTeam = myTeam;

        //}
        //if (MasterManager.nextPlayersTeam == 2)
        //{
        //    myIdtext.text = "Red";
        //    Indicator.color = Color.red;
        //    NameBar.color = Color.red;
        //    GetComponent<Shoot>()._myTeam = myTeam;

        //}

        //photonView.RPC("RPC_SentTeam",RpcTarget.All,myTeam);
        photonView.RPC("RPC_SentTeam",RpcTarget.OthersBuffered,myTeam);
        
    }
    [PunRPC]
    void RPC_SentTeam(int WhichTeam)
    {
        myTeam = WhichTeam;
      

    }
    


}
