using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;
    [SerializeField]
    private TextMeshProUGUI _readyUpText;
    private bool _ready = false;
    private List<PlayerListing> _listing = new List<PlayerListing>();
    private RoomsCanvases _roomsCanvases;
    //ekleme
    [SerializeField]
    private CharacterSelectMenuController _characterSelectMenuController;
    public CharacterSelectMenuController CharacterSelectMenuController { get { return _characterSelectMenuController; } }
    //bitti
    private void Awake()
    {
        GetCurrentRoomPlayer();
    }
    public override void OnEnable()
    {
        base.OnEnable();
        SetReadyUp(false);
    }
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;

    }
    private void SetReadyUp(bool state)
    {
        _ready = state;
        if (_ready) { _readyUpText.text = "Ready"; }
        else
        {
            _readyUpText.text = "Not Ready!";
        }
        
    }
    public override void OnLeftRoom()
    {
        _content.DestroyChildren();
    }
    private void GetCurrentRoomPlayer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        if (PhotonNetwork.CurrentRoom == null||PhotonNetwork.CurrentRoom.Players==null)
            return;

        foreach (KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    public void AddPlayerListing(Player player)
    {
        PlayerListing listing = Instantiate(_playerListing, _content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            _listing.Add(listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _roomsCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listing.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listing[index].gameObject);
            _listing.RemoveAt(index);
        }
    }
    
    public void OnClick_StartGame()
    {
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    //for (int i = 0; i < _listing.Count; i++)
        //    //{
        //    //    if (_listing[i].Player!=PhotonNetwork.LocalPlayer)
        //    //    {
        //    //        if (!_listing[i].Ready)
        //    //        {
        //    //            return;
        //    //        }
        //    //    }
        //    //}
        //    PhotonNetwork.CurrentRoom.IsOpen = false;
        //    PhotonNetwork.CurrentRoom.IsVisible = false;//Baskalari odayi görsun istersen iptal et
        //    PhotonNetwork.LoadLevel(1);

        //}
        //ekleme
        _characterSelectMenuController.gameObject.SetActive(true);
    }
    public void OnClick_ReadyUp()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!_ready);
            base.photonView.RPC("RPC_ChangeReadyStaté", RpcTarget.MasterClient,PhotonNetwork.LocalPlayer,_ready);
            //sifreleme
            //base.photonView.RpcSecure("RPC_ChangeReadyStaté", RpcTarget.MasterClient,true,PhotonNetwork.LocalPlayer,_ready);
        }
    }  
    private void RPC_ChangeReadyState(Player player ,bool ready)
    {
        int index = _listing.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listing[index].Ready = ready;
          
        }
    }

}
