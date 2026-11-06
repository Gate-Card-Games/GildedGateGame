using UnityEngine;


public class getHandPosition : MonoBehaviour
{

    [SerializeField] LayerMask cardLayer;
    [SerializeField] DislpayHand hand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(raycast, out hit, Mathf.Infinity, cardLayer))
            {
                PositionInHand posInHand = hit.transform.gameObject.GetComponent<PositionInHand>();
                hand.setCardOn(posInHand.getPositionInHand());
            }
        }
    }

  
}
