using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMove : MonoBehaviour
{  
    
    public float bulletSpeed = 100f;
    float Range = 100;
    public float damageValue = 50f;
    Rigidbody rb;
    Vector3 startPos;
    public void start()
    { 
        
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(startPos, transform.position);
        if (distance>Range)
        {
            this.gameObject.SetActive(false);
            transform.position = startPos;
        }
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);

    }

    private void OnTriggerEnter(Collider other)
    {
        string otherObjectName = other.gameObject.name;
        
        this.gameObject.SetActive(false);
       
        
        Debug.Log("<color=yellow>Hit</color>"+otherObjectName);
    }
}

  

