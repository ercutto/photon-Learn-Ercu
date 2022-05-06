using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();
    [SerializeField]
    private Text _text;
    public void OnClick_CustomRandomGeneratorButton() { SetCustomNumber(); }

    private void SetCustomNumber()
    {
        int result = Random.Range(0, 99);
        _text.text = result.ToString();
        _myCustomProperties["RandomNumber"] = result;

        PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);
        //PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
    }
}
