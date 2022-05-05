using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to Server");
        PhotonNetwork.AutomaticallySyncScene = true;
        /*local nickname*/PhotonNetwork.NickName = MasterManager.GameSettings.NickName;//from scriptable object
        PhotonNetwork.GameVersion = MasterManager.GameSettings.NickName;//from scriptable object
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        print("Connected to server");
        print("Nickname: " + PhotonNetwork.LocalPlayer.NickName);
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
        
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected" + cause.ToString());
    }

}

