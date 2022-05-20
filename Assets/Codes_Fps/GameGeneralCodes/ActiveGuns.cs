using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ActiveGuns : MonoBehaviour,IPunObservable
{
    public List<GameObject> weaponObjects;


    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            foreach (GameObject obj in weaponObjects)
            {
                stream.SendNext(obj.activeSelf);
            }
        }
        else
        {
            foreach (GameObject obj in weaponObjects)
            {
                obj.SetActive((bool)stream.ReceiveNext());
            }
        }
    }
}
