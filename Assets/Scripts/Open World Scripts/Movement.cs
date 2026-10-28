using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 axis;
    private void Update()
    {
        axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
