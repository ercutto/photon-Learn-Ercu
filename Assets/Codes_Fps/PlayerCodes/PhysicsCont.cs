
using Photon.Pun;
using UnityEngine;

public class PhysicsCont : MonoBehaviourPunCallbacks
{
    public Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;

    public CharacterController controller;
    public Cards cards;
    public float jumpSeed;
    // Start is called before the first frame update
    void Start()
    {

        cards = GetComponent<Players>().Cards;
        controller = GetComponent<CharacterController>();
        jumpSeed = cards.JumpSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpSeed * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
