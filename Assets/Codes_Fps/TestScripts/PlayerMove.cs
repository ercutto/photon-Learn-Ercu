using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    public float speed=5;
   
  
    public GameObject headRotator,gunRotator;
 
  
    public float gunX;
    float vertical, headHorizontal, headVertical,horizontal;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
      
      
        
    }

    // Update is called once per frame
    void Update()
    {
        //from = this.transform.rotation;
      
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        headHorizontal = Input.GetAxis("Mouse X") * 1000f * Time.deltaTime;
        headVertical = Input.GetAxis("Mouse Y");
       
        
       
        

    }
    public void LateUpdate()
    {
        transform.Translate(horizontal, 0, vertical);
        transform.Rotate(0, headHorizontal, 0);
        headRotator.transform.Rotate(-headVertical, 0, 0);
        gunRotator.transform.Rotate(-headVertical, 0, 0);
        gunX = gunRotator.transform.rotation.x;
    }
}
