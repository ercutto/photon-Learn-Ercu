using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed=5;
    public float runSpeed;
    bool runSelected;
 
    public GameObject headRotator,gunRotator;
    float rotHorizontal, rotVertical;
 
  
    public float gunX;
    float vertical, headHorizontal, headVertical,horizontal;
    //Player Angles
    float AngleY, AngleX, AngleZ;
    //Head Angles
    float Angle_Head_Y, Angle_Head_X, Angle_Head_Z;
    //GunRotator Angles
    float Angle_Gun_Y, Angle_Gun_X, Angle_Gun_Z;
    private float sensetivity=3;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        runSelected = false;
        RotationAngles();
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        //Wasd inputs only for moves
        Inputs();
        //for move
        Move();
        //for rotate
        Turn();
    }
    #region Inputs
    void Inputs()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        //Mous inputs fro all turns
        rotVertical = Input.GetAxis("Mouse Y")*sensetivity;
        rotHorizontal = Input.GetAxis("Mouse X")*sensetivity;

        if (rotVertical < 0.5f && rotVertical < 0.5f)
        {
            gunRotator.transform.Rotate(0, 0, 0);
            headRotator.transform.Rotate(0, 0, 0);
        }
    }
    #endregion
    #region Move
    void Move()
    {
        Vector3 move = Vector3.zero;
        move = new Vector3(horizontal, 0, vertical);
        if (move.sqrMagnitude > 1.0f) move.Normalize();

        float currentSpeed = runSelected ? runSpeed : walkSpeed;
        move = move * currentSpeed * Time.deltaTime;
        transform.Translate(move);
    }
    #endregion
    #region Turn
    void Turn()
    {
        AngleY = rotHorizontal;
        Angle_Gun_X = rotVertical;
        Angle_Head_X = rotVertical;
        Angle_Gun_X = Mathf.Clamp(Angle_Gun_X, -70, 70);
        Angle_Head_X = Mathf.Clamp(Angle_Head_X, -70, 70);
        gunRotator.transform.Rotate(Angle_Gun_X, 0, 0);
        headRotator.transform.Rotate(Angle_Head_X, 0, 0);
        //gunRotator.transform.eulerAngles=new Vector3(Mathf.Clamp(Angle_Gun_X,- 70, 70),0,0);    
        //headRotator.transform.rotation = Quaternion.Euler(Mathf.Clamp(Angle_Head_X,- 70, 70),0,0);
        transform.Rotate(AngleX, AngleY, AngleZ);
    }

    #endregion
    #region Angles
    void RotationAngles()
    {
        AngleX = transform.localEulerAngles.x;
        AngleY = transform.localEulerAngles.y;
        AngleZ = transform.localEulerAngles.z;
        Angle_Head_X = headRotator.transform.localEulerAngles.x;
        Angle_Head_Y = headRotator.transform.localEulerAngles.y;
        Angle_Head_Z = headRotator.transform.localEulerAngles.z;
        Angle_Gun_X = gunRotator.transform.localEulerAngles.x;
        Angle_Gun_Y = gunRotator.transform.localEulerAngles.y;
        Angle_Gun_Z = gunRotator.transform.localEulerAngles.z;
        //rotVertical = 90;
        //rotHorizontal = 0;
    }
    #endregion
    #region CursorStates
    void OnGUI()
    {
        //Press this button to lock the Cursor
        if (GUI.Button(new Rect(0, 0, 100, 50), "Lock Cursor"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        //Press this button to confine the Cursor within the screen
        if (GUI.Button(new Rect(125, 0, 100, 50), "Confine Cursor"))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    #endregion
}
