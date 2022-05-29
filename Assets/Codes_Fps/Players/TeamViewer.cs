using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamViewer : MonoBehaviourPunCallbacks
{
    public Image Indicator;
    public int myId;
    public Text myIdtext;
    private InstatiateExample Instantiator;
 
    // Start is called before the first frame update
    void Start()
    {
       
        if (photonView.IsMine)
        {
            Instantiator = GameObject.Find("Instantiation").GetComponent<InstatiateExample>();
            
            photonView.RPC("SenMyColorInf", RpcTarget.All);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [PunRPC]
    void SenMyColorInfo()
    {
        Indicator.color = Color.blue;
        myIdtext.text = myId.ToString();
    }
}
