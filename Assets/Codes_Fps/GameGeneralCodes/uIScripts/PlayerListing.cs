using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI _text;
    public Player Player { get; private set; }
    public bool Ready = false;
    public void SetPlayerInfo(Player player)
    {
        Player = player;
        SetPlayertext(player);
       
       
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if (targetPlayer != null && targetPlayer == Player)
        {
            if (changedProps.ContainsKey("RandomNumber"))
                SetPlayertext(targetPlayer);
        }
    }
    private void SetPlayertext(Player player)
    {
        int result = -1;

        if (player.CustomProperties.ContainsKey("RandomNumber"))
            result = (int)player.CustomProperties["RandomNumber"];
        _text.text = result.ToString() + ", " + player.NickName;
    }


}
