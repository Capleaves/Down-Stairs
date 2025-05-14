using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 1.5f;
    public float speedBoostMultiplier = 2f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal,0f,vertical);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            movement *= speed * speedBoostMultiplier;
        }
        else
        {
            movement *= speed;
        }

        controller.Move(movement * Time.deltaTime);
    }

    void Jump()
    {
        if(isGrounded && Input.GetKey(KeyCode.Space))
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -3.0f * Physics.gravity.y);
            isGrounded = false;
        }

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
