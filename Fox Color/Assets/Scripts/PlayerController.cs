using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //walking spead
    public float walkSpeed = 5;

    //jumping speed
    public float jumpForce = 1;

    //Rigidbody component
    Rigidbody2D rb;

    //Collider component
    Collider2D col;

    //flag to keep track of key pressing
    bool pressedJump = false;

    //size of the player
    Vector2 size;

    public LayerMask groundLayer;

    // Use this for initialization
    void Start()
    {
        // Grab our components
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // get player size
        size = col.bounds.size;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WalkHandler();
        JumpHandler();
    }

    // Takes care of the walking logic
    void WalkHandler()
    {
        // Input on x (Horizontal)
        float xAxis = Input.GetAxis("Horizontal");
        
        // Movement vector
        Vector2 movement = new Vector2(xAxis * walkSpeed * Time.deltaTime, 0);

        // Calculate the new position
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y) + movement;

        // Move
        rb.MovePosition(newPos);
    }

    // takes care of the jumping logic
    void JumpHandler()
    {
        // Input on the Jump axis
        float yAxis = Input.GetAxis("Jump");

       

        // If the key has been pressed
        if (yAxis > 0)
        {
            bool isGrounded = CheckGrounded();
            print(isGrounded);
            //make sure we are not already jumping
            if (!pressedJump && isGrounded)
            {
                pressedJump = true; 

                //jumping vector
                Vector2 jumpVector = new Vector2(0, yAxis * jumpForce);

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y) + jumpVector;
                rb.MovePosition(newPos);

            }
        }
        else
        {
            //set flag to false
            pressedJump = false;
        }
    }

    // will check if the player is touching the ground
    bool CheckGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = size.y/2 +0.03f;

       
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}

