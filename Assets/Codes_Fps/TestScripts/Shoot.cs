using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviourPun
{
    public GunsStat _gunStat;
    public GameObject bullet;
    public int bulletCapacity;
    public Transform[] ShotPos;
    private int Clicked;
    public Text bulletText;

    // Start is called before the first frame update
    void Start()
    {

        bulletCapacity = _gunStat.capacity;
        Clicked = bulletCapacity;

        bulletText.text = bulletCapacity.ToString();
        //PhotonNetwork.Instantiate(bullet.name, ShotPos[0].transform.position, ShotPos[0].transform.transform.rotation);

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

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

        yield return new WaitForSeconds(2);
        bulletCapacity = _gunStat.capacity;
        bulletText.text = bulletCapacity.ToString();
        Clicked = bulletCapacity;
    }


}
