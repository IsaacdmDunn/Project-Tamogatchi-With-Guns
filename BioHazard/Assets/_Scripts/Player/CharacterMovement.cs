using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDist = 2f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool isGrounded;
    [SerializeField] bool canWallJump;
    [SerializeField] int wallJumps = 0;
    [SerializeField] float speed = 12f;
    [SerializeField] float wallDropDampener = 12f;
    float wallRunAngle = 0f;
    [SerializeField] float wallRunAngleOffset = 0f;
    [SerializeField] float sprintMod = 1.25f;
    [SerializeField] float jump = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Vector3 velocity;
    Vector3 move;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        MovePlayer();
        PlayerJump();
    }

    //player jump
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded || (canWallJump && wallJumps < 3)))
        {
            velocity.y = Mathf.Sqrt(jump * -2 * gravity);
            canWallJump = false;

            if (canWallJump)
            {
                wallJumps++;
                gameObject.GetComponent<Rigidbody>().AddForce(-move * 5, ForceMode.Force);
                //controller.Move(-move * speed * Time.deltaTime);
            }
        }
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
    }

    //moves player
    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speed * sprintMod * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }


        
    }

    //checks if player is on ground
    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded && canWallJump && velocity.y < 0)
        {
            velocity.y = 0f;
            //wallJumps = 0;
        }

        if (canWallJump == true)
        {
            velocity.y = -wallDropDampener;
        }
    }

    void SetWallRunAngle()
    {
        //get wall angle and direction running on wall
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
           
            canWallJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallRunAngle = 0f;
            canWallJump = false;
        }
    }
}
