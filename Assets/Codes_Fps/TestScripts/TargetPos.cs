using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = (Input.GetAxis("Mouse Y"));
        float y = (Input.GetAxis("Mouse X"));
        transform.position= new Vector3(x,-y,0);
    }
}
