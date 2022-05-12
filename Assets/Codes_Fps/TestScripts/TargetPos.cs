
using Photon.Pun;
using UnityEngine;

public class TargetPos : MonoBehaviourPunCallbacks
{
    public float sensetivity = 300;
    public Transform camPos,player;
    public GameObject camHolder;
    private float xRot=0;
    void Start()
    {
        if (photonView.IsMine)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
{
        if (photonView.IsMine) {
            float y = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
            float x = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;
            xRot -= x;
            xRot = Mathf.Clamp(xRot, -87f, 87f);
            camHolder.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            camHolder.transform.position = camPos.transform.position;
            player.Rotate(Vector3.up * y);
        }
        else
        {
            camHolder.SetActive(false);
        }
           
            

    }
}
