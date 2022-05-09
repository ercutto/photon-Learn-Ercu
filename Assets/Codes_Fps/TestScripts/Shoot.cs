using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject bullet;
    public Transform[] ShotPos;
    public bool IsFiring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet,ShotPos[0].transform.position, ShotPos[0].transform.transform.rotation);
                Instantiate(bullet,ShotPos[1].transform.position, ShotPos[1].transform.transform.rotation);

        }

        
    
       
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

            if (stream.IsWriting)
            {
                // We own this player: send the others our data

                stream.SendNext(IsFiring);

            }
            else
            {
                // Network player, receive data
                this.IsFiring = (bool)stream.ReceiveNext();
            }

        
    }
}
