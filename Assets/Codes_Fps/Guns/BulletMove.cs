using Photon.Pun;
using UnityEngine;

public class BulletMove : MonoBehaviourPunCallbacks,IPunObservable
{
    public bool shooting;
    public float bulletSpeed = 100f;
    float Range = 100;
    public float damageValue = 50f;
    public int team = 0;
    Rigidbody rb;
    
    Vector3 startPos;
    public void Start()
    {
     
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        Debug.Log("<color=green> BulletTeam :</color>"+team);
    }
   
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(startPos, transform.position);
        if (distance>Range)
        {
            Destroy(gameObject);
           
        }

        //transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);

    }
    
    private void OnTriggerEnter(Collider other)
    {
        string otherObjectName = other.gameObject.name;

        Destroy(gameObject);

        //this.transform.position = Vector3.zero;

        Debug.Log("<color=yellow>Hit</color>"+otherObjectName);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            
        }
        else
        {

            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
            
        }
    }
}

  

