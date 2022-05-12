using UnityEngine;

public class BulletMove : MonoBehaviour 
{
    public bool shooting;
    public float bulletSpeed = 100f;
    float Range = 100;
    public float damageValue = 50f;
    Rigidbody rb;
    
    Vector3 startPos;
    public void Start()
    { 
        
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }
   
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(startPos, transform.position);
        if (distance>Range)
        {
            Destroy(gameObject);
            transform.position = startPos;
        }
       
            
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);

    }

    private void OnTriggerEnter(Collider other)
    {
        string otherObjectName = other.gameObject.name;
        
        this.gameObject.SetActive(false);
    
        //this.transform.position = Vector3.zero;
        
        Debug.Log("<color=yellow>Hit</color>"+otherObjectName);
    }
   
}

  

