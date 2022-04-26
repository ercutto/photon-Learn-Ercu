using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPos : MonoBehaviour
{
    public float sensetivity = 300;
    public Transform playerBody;
    private float xRot=0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        float x = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;
        xRot -= x;
        xRot = Mathf.Clamp(xRot, -87f, 87f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * y);

    }
}
