using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            //GameObject newObj = ObjectPooler.SharedInstance.GetpooledObject();
            //if (newObj != null)
            //{

            //    newObj.transform.SetPositionAndRotation(transform.position, transform.rotation);
            //    newObj.SetActive(true);
            //}
        }
    }
}