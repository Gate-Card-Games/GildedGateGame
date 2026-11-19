/**The Purpose of this function is to get a path from the starting object to the ending
 * 
 * @author ryan weinstein
 * 
 * Collaborators N\A
 * 
 */

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AStar : MonoBehaviour
{
    [SerializeField] private GridManager grid;

    [SerializeField] private GameObject start;

    [SerializeField] private GameObject end;

    /**Summary:
     *      finds where the object to start searching from is
     * 
     * Return:
     *      the object to start from
     */
    private GameObject getStart()
    {
        GameObject[,] obj = grid.getItemsInGrid();

        for(int i = 0; i < obj.GetLength(0); i++)
        {
            for(int j = 0; j < obj.GetLength(1); j++)
            {
                if (obj[i, j] == default)
                    continue;
                if (obj[i, j].tag == "Start")
                {
                    return obj[i, j];
                }
            }
        }

        return default;
    }

    /**Summary:
     *      finds where the object to end searching from is
     * 
     * Return:
     *      the object to end at
     */
    private GameObject getEnd()
    {
        GameObject[,] obj = grid.getItemsInGrid();

        for (int i = 0; i < obj.GetLength(0); i++)
        {
            for (int j = 0; j < obj.GetLength(1); j++)
            {
                if (obj[i, j] == default)
                    continue;
                if (obj[i,j].tag == "End")
                {
                    return obj[i, j];
                }
            }
        }

        return default;
    }

    /**Summary:
     *      Returns all of the spots next to the given cell position
     *      
     *Parameter:
     *      pos:
     *          the position of the cell you want the neighbors of
     *          
     *Return:
     *      the Vector3 of the spots in the grid next to the given position
     * 
     */
    private List<Vector3> getNeighbors(Vector3 pos)
    {

        List<Vector3> validNeighbors = new List<Vector3>();

        List<int> neighborLocs = grid.getAllNeighbors(pos);

        GameObject[,] items = grid.getItemsInGrid();

        for(int i = 0; i < neighborLocs.Count; i++)
        {
            int index = neighborLocs[i];
            
            int x = index % grid.getWidth();

            int y = index / grid.getWidth();

            if (isPosNull(y,x))
            {
                continue;
            }
            else
            {

                validNeighbors.Add(items[y, x].transform.position);
            }
        }

        return validNeighbors;
    }

    /**Summary:
     *      Finds the shortest path from the start to the end in the grid
     * 
     * Return:
     *      the shortest path in the grid from start to end
     * 
     */
    public List<Vector3> locate()
    {
        HashSet<Vector3> visited = new HashSet<Vector3>();

        List<Vector3> path = new List<Vector3>();

        Vector3 current = getStart().transform.position;

        path.Add(current);

        Vector3 endPos = getEnd().transform.position;

        PriorityQueue<AStarHelper> pq = new PriorityQueue<AStarHelper>();

        AStarHelper startingPos = new AStarHelper();

        startingPos.setPath(path);

        startingPos.setEnd(endPos);



        pq.add(startingPos);



        int maxTries = (int)(grid.getHeight() * grid.getWidth());



        for (int i = 0; i < maxTries && (endPos.x != current.x || endPos.z != current.z); i++)
        {
            AStarHelper helper = pq.poll();
            if(helper == default(AStarHelper))
            {
                Debug.Log("Not Possible, Found at Point: " + i);
                break;
            }

            path = helper.getPath();


            current = path[path.Count - 1]; //gets the latest one added

            visited.Add(current); //may be able to be removed

            List<Vector3> neigbors = getNeighbors(current);


            for(int j = 0; j < neigbors.Count;j++) //adds the neigbors
            {
                Vector3 spot = neigbors[j];
                if (visited.Contains(spot)) //makes sure it wasn't used before
                    continue;


                visited.Add(spot);

                List<Vector3> newPath = path.ToList();

                newPath.Add(spot);

                AStarHelper next = new AStarHelper();

                next.setPath(newPath);

                next.setEnd(endPos);
                

                pq.add(next);
            }

        }


        return path;
    }

    /**Summary:
     *      just used for the button
     * 
     */
    public void basicFun()
    {
        List<Vector3> path = locate(); //Currently Has Bugs 

        Debug.Log("Path Length: " + path.Count); //just tells us the length of the path it got


    }



    /**Summary:
     *      sees if the position is null and returns if it is
     *      
     *Parameter:
     *      x:
     *          the first point in the grid or height
     *      y:
     *          the second point in the grid or width
     *          
     *Return:
     *  true if the square is null and false if it isn't
     * 
     */
    private bool isPosNull(int x, int y)
    {
        GameObject[,] gridArr = grid.getItemsInGrid();

        if (gridArr[x , y] == default)
        {
            return true;
        }

        return false;
    }

}
