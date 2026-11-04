using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5;
    public float jumpForce;
    public float jumpCooldown;
    public float airMult;
    bool readyToJump = true;


    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    bool grounded;


    private float horizontalInput;
    private float verticalInput;

    private KeyCode jumpInput = KeyCode.Space;
    
    public Transform orientation;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private void Awake()
    {
        rb  = GetComponent<Rigidbody>();

    }
    private void Update()
    {

        GroundCheck();
        InputFunc();
        SpeedControl();
        
       
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    void InputFunc()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
      

        if(Input.GetKeyDown(jumpInput) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    void MoveCharacter()
    {
       moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
        {
            rb.AddForce(moveDirection * speed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection * speed * 10f * airMult, ForceMode.Force);

        }

        
    }
    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);


    }
    void GroundCheck()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer); 

        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0f;
        }
    }
    void SpeedControl()
    {
        Vector3 flatV = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        if (flatV.magnitude > speed)
        {
            Vector3 limitV = flatV.normalized * speed;
            rb.linearVelocity = new Vector3(limitV.x, rb.linearVelocity.y, limitV.z);
        }
    }
    void ResetJump()
    {
        readyToJump = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f));
    }

}
