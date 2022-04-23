using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform rayPos;
    public Camera cam;
    public GameObject bullet;
    public GameObject player;
    public GameObject targetPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.
        }

        //RaycastHit hit;
        //if (Physics.Raycast(rayPos.transform.position, cam.transform.forward, out hit, 50f))
        //{
           
        //        this.transform.LookAt(hit.point);
        //        Debug.DrawRay(rayPos.transform.position, cam.transform.forward * hit.distance, Color.yellow);
        //        Debug.Log("Did Hit");
            

        //}
        //else
        //{
            
        //    this.transform.LookAt(cam.WorldToScreenPoint(Vector3.forward));
        //    Debug.DrawRay(rayPos.transform.position, cam.transform.forward * 1000, Color.white);
        //    Debug.Log("Did not Hit");
        //}
       
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            ShotNow();


        }
    }
    void ShotNow()
    {
        GameObject newbullet = SimpleObjectPooler.instance.GetPooledObject();
        if (newbullet != null)
        {
            newbullet.transform.position = rayPos.transform.position;
            newbullet.transform.rotation = rayPos.rotation;
            newbullet.SetActive(true);
            
        }
        
    }
}
