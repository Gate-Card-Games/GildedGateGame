using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float rayDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractButton();
        }
        
    }
    void InteractButton()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, rayDistance);
        EnemyNPC enemyNPC = hit.transform.GetComponent<EnemyNPC>();
        if (enemyNPC != null)
        {
            enemyNPC.OnInteracted();
        }
    }
}
