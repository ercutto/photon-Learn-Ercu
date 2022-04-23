using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float bulletSpeed = 500f;
    bool keepFalse;
    void Start()
    {
        
    }
    void Update()
    {
       
        transform.Translate(Vector3.forward  * bulletSpeed* Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        keepFalse = true;
       
    }
}
