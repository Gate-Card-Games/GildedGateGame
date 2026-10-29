using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridPlacer : MonoBehaviour
{
    public GameObject boxTest;
    public Transform title;
    public Grid grid;
    public LayerMask placementLayer;

    [SerializeField] DislpayHand dHand;

    [SerializeField] Hand hand;

    private HashSet<Vector3> occupiedPosition = new HashSet<Vector3>();


    public void changePlacer(GameObject newObj)
    {
        boxTest = newObj;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, placementLayer))
        {
            Vector3Int cellPos = grid.WorldToCell(hit.point);

            Vector3 snappedWorldPos = grid.GetCellCenterWorld(cellPos);

            title.position = snappedWorldPos;
            if (Input.GetMouseButtonDown(0))
            {
                // Sees if the card is defensive and then plays it
                if (dHand != null)
                {
                    var t = hand.playCard(dHand.getCardOn());

                    if (t != null)
                    {
                        GameObject card = t as GameObject;

                        if (!occupiedPosition.Contains(title.position))
                        {
                            var work = Instantiate(card, title.position, Quaternion.identity);
                            occupiedPosition.Add(work.transform.position);
                            //dHand.removeCardOn();
                            dHand.setCardOn(-1);
                            
                        }

                    }
                }
                

            }
        }

    }

}
