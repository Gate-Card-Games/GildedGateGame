using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpHeight;
    public LayerMask groundLayer;
    private bool groundCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {
        //Ground Check for the player
        if (Physics2D.Raycast(transform.position, -Vector2.up, 1.2f, groundLayer))
        {
            groundCheck = true;
        }
        else
        {
            groundCheck = false;
        }
            

        //Input to velocity on  X axis
        rb.linearVelocityX = Input.GetAxisRaw("Horizontal") * speed;
        //Jump input
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) && groundCheck))
        {
            rb.linearVelocityY = jumpHeight;
        }
           
       
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Death")
        {
            Destroy(gameObject);
        }
    }

}
