
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrackPlacer : MonoBehaviour
{
    public GameObject boxTest;
    public Transform title;
    public GridManager grid;
    public LayerMask placementLayer;


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
            Vector3 snappedWorldPos = grid.getCellCenter(hit.point);

            snappedWorldPos.y += grid.getCellSize() / 2;



            title.position = snappedWorldPos;
            if (Input.GetMouseButtonDown(0))
            {

                        if (!occupiedPosition.Contains(title.position))
                        {
                            var work = Instantiate(boxTest, title.position, Quaternion.identity);
                            grid.placeObject(work, snappedWorldPos);
                            occupiedPosition.Add(work.transform.position);

                        }

                


            }
        }

    }
}
