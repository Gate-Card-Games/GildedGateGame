using Unity.Cinemachine;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform playerObj;
    public Transform orientation;
    public float rotationSpeed;
    private bool frozen = false;
    private CinemachineBrain cBrain;

    private void Start()
    {
        cBrain = GetComponent<CinemachineBrain>();
        FreezeMouse();
        
    }
    public void UnFreezeMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        frozen = true;
        cBrain.enabled = false;
    }
    public void FreezeMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        frozen = false;
        cBrain.enabled = true;
    }
    void MovePlayer()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        float horizonatalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizonatalInput;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);

        }
    }
    private void Update()
    {
        if(!frozen)
            MovePlayer();
          
    }
    
}
