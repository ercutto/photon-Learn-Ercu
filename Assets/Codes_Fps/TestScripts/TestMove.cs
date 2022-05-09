using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviourPunCallbacks
{
    private float speed = 3;
    private CharacterController controller;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine) { controller=GetComponent<CharacterController>(); cam = GameObject.Find("Cam").GetComponent<Camera>();
            cam.transform.SetParent(transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * y;

            controller.Move(speed * Time.deltaTime * move);

        }
    }
}
