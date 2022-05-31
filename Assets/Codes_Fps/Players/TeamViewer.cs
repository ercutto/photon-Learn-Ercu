using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeamViewer : MonoBehaviourPun
{
    public Image Indicator;
    public int myTeam;
    public Text myIdtext;
    public bool mycolor;
    
    private InstatiateExample Instantiator;

    // Start is called before the first frame update
    void Awake()
    {

        if (photonView.IsMine)
        {
            photonView.RPC("RPC_GetTeam", RpcTarget.AllBuffered);
            //photonView.RPC("RPC_GetTeam", RpcTarget.MasterClient);
        }
        
    }
 
    [PunRPC]
    void RPC_GetTeam()
    {
        myTeam = MasterManager.nextPlayersTeam;
        GetComponent<Shoot>()._myTeam = myTeam;
        if (myTeam == 1)
        {
            myIdtext.text = "Blue";
            Indicator.color = Color.blue;
        }
        else
        {
            myIdtext.text = "Red";
            Indicator.color = Color.red;
        }
        MasterManager.UpdateTeam();
        photonView.RPC("RPC_SentTeam",RpcTarget.AllBuffered,myTeam);
        //photonView.RPC("RPC_SentTeam",RpcTarget.OthersBuffered,myTeam);
    }
    [PunRPC]
    void RPC_SentTeam(int WhichTeam)
    {
        myTeam = WhichTeam;
    }
}
