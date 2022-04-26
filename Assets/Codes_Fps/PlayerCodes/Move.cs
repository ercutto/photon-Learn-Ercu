using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{   [SerializeField]
    private CharacterController controller;
    public Cards card;
    [SerializeField]
    protected float speed;
    public bool isFast;
    public float fastSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isFast = false;
        speed = card.speed;
        controller.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        if (isFast)
        {
            controller.Move(move * fastSpeed * Time.deltaTime);

        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

    }
}
