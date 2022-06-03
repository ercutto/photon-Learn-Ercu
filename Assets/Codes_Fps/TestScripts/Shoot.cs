using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviourPun
{
    public Players players;
    public GameObject bullet;
    public int bulletCapacity;
    private float reloadTime;
    private float repeatTime;
    public Transform[] ShotPos;
    private int Clicked;
    public Text bulletText;
    public TeamViewer teamViewer;
  

    // Start is called before the first frame update
    void Start()
    {
        if (!players) {players= GetComponent<Players>(); }
        reloadTime = players.GunReloadTime;
        repeatTime = players.gunRepeatTime;
        bulletCapacity =players.gunCapacity;
        Clicked = bulletCapacity;

        bulletText.text = bulletCapacity.ToString();
        //PhotonNetwork.Instantiate(bullet.name, ShotPos[0].transform.position, ShotPos[0].transform.transform.rotation);
      
    }

    void Update()
    {
        repeatTime -= Time.deltaTime;
        if (Input.GetMouseButton(0)&&repeatTime<=0)
        {
            repeatTime = players.gunRepeatTime;
            if (Clicked > 0)
            {

                FireClicked();
                
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
    void FireClicked()
    {
        photonView.RPC("RPC_Fire", RpcTarget.All);
    }
    [PunRPC]
    void RPC_Fire()
    {
       GameObject _bullet = Instantiate(bullet, ShotPos[0].transform.position, ShotPos[0].transform.transform.rotation);
        Rigidbody _bullet_rb = _bullet.GetComponent<Rigidbody>();

        _bullet_rb.AddForce(10000 * Time.deltaTime * ShotPos[0].transform.forward,ForceMode.Impulse);

    }
    IEnumerator Reload()
    {

        yield return new WaitForSeconds(reloadTime);
        bulletCapacity = players.gunCapacity;
        bulletText.text = bulletCapacity.ToString();
        Clicked = bulletCapacity;
    }


}
