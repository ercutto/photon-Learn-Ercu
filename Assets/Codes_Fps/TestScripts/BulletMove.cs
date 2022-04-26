using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMove : MonoBehaviour
{  
    
    float bulletSpeed = 100f;
    
    Rigidbody rb;
    public void start()
    { 
        rb = GetComponent<Rigidbody>();
        
    }
    private void FixedUpdate()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);

    }

    private void OnTriggerEnter(Collider other)
    {
        string otherObjectName = other.gameObject.name;
        
        this.gameObject.SetActive(false);
       
        
        Debug.Log("<color=yellow>Hit</color>"+otherObjectName);
    }
}

  

