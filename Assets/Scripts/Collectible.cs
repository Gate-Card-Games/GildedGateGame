using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float point;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        Destroy(gameObject);
    }
}
