using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject rayPosObject;
    public Transform rayPos;
    public Camera cam;
    public GameObject bullet;
    public GameObject player;
    public GameObject targetPos;
   

    // Start is called before the first frame update
    public void Start()
    {
        rayPos = rayPosObject.transform;
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            rayPos.transform.LookAt(hit.point);
        }
        else
        {


        }
        if (Input.GetKey(KeyCode.Mouse0))
        {

            GameObject newObj = ObjectPooler.SharedInstance.GetpooledObject();
            if (newObj != null)
            {

                newObj.transform.SetPositionAndRotation(rayPos.position, rayPos.rotation);
                newObj.SetActive(true);
            }

        }

    }
    public  void Update()
    {
        
    }
  

  
}
