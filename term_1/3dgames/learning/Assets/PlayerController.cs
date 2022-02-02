using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 3.5f;
    public float speed = 2f;
    public float jumpForce = 0.5f;

    private CharacterController controller;
    private Vector3 motion;
    private float currentSpeed = 0;
    private float velocity = 0;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        currentSpeed = speed;
    }

    private void FixedUpdate()
    {
        motion = Vector3.zero;
        bool grounded = controller.isGrounded;

        if (grounded == true)
        {
            velocity = -gravity * Time.deltaTime;
        }
        else

        {
            velocity -= gravity * Time.deltaTime;
        }
    }

    void Update()
    {
        if (controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
                velocity = jumpForce;
        }
        ApplyMovement();
    }

    void ApplyMovement()
    {
        float inputX = Input.GetAxisRaw("Vertical") * currentSpeed;
        float inputY = Input.GetAxisRaw("Horizontal") * currentSpeed;
        motion += transform.forward * inputX * Time.deltaTime;
        motion += transform.right * inputY * Time.deltaTime;
        motion.y += velocity * Time.deltaTime;
        controller.Move(motion);
    }
}
