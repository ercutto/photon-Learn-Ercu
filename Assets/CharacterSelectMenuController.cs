using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelectMenuController : MonoBehaviour
{
    public Image selectedCharacter;
    public Image selectedGun;
    public GameObject button;
    private bool characterReady, gunReady;
   
    public Cards[] Thiscard;

    public int cardID;

    public GunsStat[] ThisGun;

    public int gunID;
    public void CardSelecting(int cardID)
    {
        MasterManager.card = Thiscard[cardID];
        selectedCharacter.sprite = MasterManager.card.characterSprite;
        characterReady = true;
        if (gunReady)
        {
            button.gameObject.SetActive(true);
        }else { return; }
    }
    public void GunSelecting(int gunID)
    {
        MasterManager.gunStat = ThisGun[gunID];
        selectedGun.sprite = MasterManager.gunStat.gunsSprite;
        gunReady = true;
        if (characterReady)
        {
            button.gameObject.SetActive(true);
        }
        else { return; }
    }
    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //for (int i = 0; i < _listing.Count; i++)
            //{
            //    if (_listing[i].Player!=PhotonNetwork.LocalPlayer)
            //    {
            //        if (!_listing[i].Ready)
            //        {
            //            return;
            //        }
            //    }
            //}
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;//Baskalari odayi görsun istersen iptal et
            PhotonNetwork.LoadLevel(1);

        }
    }

}
