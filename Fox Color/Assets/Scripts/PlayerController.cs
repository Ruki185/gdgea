using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //walking spead
    public float walkSpeed = 5;

    //jumping speed
    public float jumpForce = 5;

    //Rigidbody component
    Rigidbody2D rb;

    //Collider component
    Collider2D col;

    //flag to keep track of key pressing
    bool pressedJump = false;

    bool pressedColorUp = false;
    bool pressedColorDown = false;

    //size of the player
    Vector2 size;

    public GameObject orbprefab;

    public LayerMask groundLayer;

    private CircularList<Color> colorList = new CircularList<Color>();

    SpriteRenderer m_SpriteRenderer;

    public float damage = 10;
    public float fallMultiplier = 28f;
    public float lowJumpMultiplier = 2f;
    public GameObject ui;

    public LayerMask whattohit;

    Transform firepoint;

    public int lifecounter;

    // Use this for initialization
    void Start()
    {
        // Grab our components
        rb = GetComponent<Rigidbody2D>();

        col = GetComponent<Collider2D>();

        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        // get player size
        size = col.bounds.size;


        colorList.Add(Color.white);
        colorList.Add(Color.blue);
        colorList.Add(Color.red);
        colorList.Add(Color.green);

        m_SpriteRenderer.color = colorList.current();

        firepoint = transform.Find("FirePoint");
        if (firepoint == null)
        {
            Debug.LogError("no firepoint");
        }

        lifecounter = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WalkHandler();
        JumpHandler();
        ColorHandler();
        LifeHandler();
        
    }

    private void Update()
    {
        FireHandler();

        if (rb.velocity.y < 0)
        {
            rb.velocity = Vector2.up * Physics2D.gravity * (fallMultiplier-1) * Time.deltaTime;
            print(rb.velocity);
            print(Time.deltaTime);
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity = Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            ui.SendMessage("LifeUpdate", this.lifecounter);
            this.lifecounter--;
        }
    }

    // Takes care of the walking logic
    void WalkHandler()
    {
        // Input on x (Horizontal)
        float xAxis = Input.GetAxis("Horizontal");
        
        // Movement vector
        Vector2 movement = Vector2.right * xAxis * walkSpeed;
        // Move
        this.transform.Translate(movement);
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
            
            //make sure we are not already jumping
            if (!pressedJump && isGrounded)
            {
                pressedJump = true;
                rb.velocity = Vector2.up * jumpForce;

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

    void ColorHandler()
    {
        float ColorUpAxis = Input.GetAxis("ColorSwitchUp");
        float ColorDownAxis = Input.GetAxis("ColorSwitchDown");

        if (ColorUpAxis > 0)
        {
            
            if (!pressedColorUp)
            {
                pressedColorUp = true;
                m_SpriteRenderer.color = colorList.next();
               
            }
        }
        else
        {
            pressedColorUp = false;
        }
        if (ColorDownAxis > 0)
        {
            if (!pressedColorDown)
            {
                pressedColorDown = true;
                m_SpriteRenderer.color = colorList.prev();
            }
        }
        else
        {
            pressedColorDown = false;
        }





    }

    void FireHandler()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        GameObject orb = Instantiate(orbprefab, firepoint.position, firepoint.rotation);
        orb.GetComponent<SpriteRenderer>().color = colorList.current();
    }

    void LifeHandler()
    {
        if (lifecounter <= 0)
        {
            print("Game Over");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Enemy"))
        {
            lifecounter -= 1;
            print(lifecounter);
        }

    }

}

public class CircularList<T> : List<T>
{
    private int idx = 0;

    public T next()
    {
        idx++;
        return this[idx % this.Count];
    }

    public T prev()
    {
        idx--;
        if (idx < 0) idx = this.Count - 1;
        return this[idx % this.Count];
    }

    public T current()
    {
        return this[idx%this.Count];
    }
}

