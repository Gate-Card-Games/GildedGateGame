using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 axis;
    public float speed = 5;
    public Transform orientation;
    private Rigidbody rb;
    private void Awake()
    {
        rb  = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        InputFunc();
        MoveCharacter();
    }
    private void FixedUpdate()
    {
        
    }
    void InputFunc()
    {
        axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
      
    }
    void MoveCharacter()
    {
        Vector3 move = (orientation.forward * axis.y + orientation.right * axis.x).normalized;
        rb.linearVelocity = move;
        
    }
    
}
