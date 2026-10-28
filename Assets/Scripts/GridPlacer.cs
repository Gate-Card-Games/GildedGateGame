using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridPlacer : MonoBehaviour
{
    public GameObject boxTest;
    public Transform title;
    public Grid grid;
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
            Vector3Int cellPos = grid.WorldToCell(hit.point);

            Vector3 snappedWorldPos = grid.GetCellCenterWorld(cellPos);

            title.position = snappedWorldPos;
            if (Input.GetMouseButtonDown(0))
            {
                if (!occupiedPosition.Contains(title.position))
                {
                    var work = Instantiate(boxTest, title.position, Quaternion.identity);
                    occupiedPosition.Add(work.transform.position);
                }

            }
        }

    }

}
