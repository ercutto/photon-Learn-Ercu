using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviourPunCallbacks, IPunObservable
{
    public GunsStat _gunStat;
    public GameObject bullet;
    public int bulletCapacity;
    public Transform[] ShotPos;
    public bool IsFiring;
    private int Clicked;
    public Text bulletText;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            bulletCapacity = _gunStat.capacity;
            Clicked = bulletCapacity;

            bulletText.text = bulletCapacity.ToString();
            //PhotonNetwork.Instantiate(bullet.name, ShotPos[0].transform.position, ShotPos[0].transform.transform.rotation);
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {if (photonView.IsMine)
        {
            if (stream.IsWriting)
            {
                Update();
            }
            else
            {

              
            }
        }

    }

    void Update()
    {
        if (photonView.IsMine) {
            if (Input.GetMouseButtonDown(0))
            {

                if (Clicked > 0)
                {
                    //photonView.RPC("RPC_Fire", RpcTarget.All);
                    RPC_Fire();
                    Clicked--;
                    bulletCapacity -= 1;
                    bulletText.text = bulletCapacity.ToString();
                    if (Clicked <= 0)
                    {
                        bulletText.text = "Reloading";
                        StartCoroutine(Reload());
                    }

                }


            }
        }
            
        
    }
    [PunRPC]
    void RPC_Fire() {

        PhotonNetwork.Instantiate(bullet.name, ShotPos[0].transform.position, ShotPos[0].transform.transform.rotation);
        //PhotonNetwork.Instantiate(bullet.name, ShotPos[1].transform.position, ShotPos[1].transform.transform.rotation);
    }
   IEnumerator Reload()
    {
       
        yield return new WaitForSeconds(2);
        bulletCapacity = _gunStat.capacity;
        bulletText.text = bulletCapacity.ToString();
        Clicked = bulletCapacity;
    }


}
