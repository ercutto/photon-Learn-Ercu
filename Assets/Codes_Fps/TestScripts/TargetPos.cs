
using UnityEngine;

public class TargetPos : MonoBehaviour
{
    public float sensetivity = 300;
    public Transform camPos,player;
    public GameObject cam;
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
            cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            cam.transform.position = camPos.transform.position;
            player.Rotate(Vector3.up * y);

    }
}
