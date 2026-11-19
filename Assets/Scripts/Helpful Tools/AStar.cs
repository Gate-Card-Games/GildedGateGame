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

    private List<Vector3> getNeighbors(Vector3 pos)
    {
        HashSet<Vector3> neighbors = new HashSet<Vector3>();

        List<Vector3> validNeighbors = new List<Vector3>();

        float cellSize = grid.getCellSize();
         //checks all of the neigbors
        //Checks the right Cell
        pos.x += cellSize; 

        if (grid.isOccupied(pos))
        {
            neighbors.Add(grid.getCellCenter(pos));
        }

        //Checks The Left Cell
        pos.x -= cellSize * 2;

        if (grid.isOccupied(pos) && !neighbors.Contains(grid.getCellCenter(pos)))
        {
            neighbors.Add(grid.getCellCenter(pos));
        }
        
        //Checks the cell above
        pos.x += cellSize; //reset

        pos.y += cellSize;

        if (grid.isOccupied(pos)&& !neighbors.Contains(grid.getCellCenter(pos)))
        {
            neighbors.Add(grid.getCellCenter(pos));
        }

        //Checks the cell below
        pos.y -= cellSize * 2;

        if (grid.isOccupied(pos) && !neighbors.Contains(grid.getCellCenter(pos)))
        {
            neighbors.Add(grid.getCellCenter(pos));
        }

        return validNeighbors;
    }

    public List<Vector3> locate()
    {
        List<Vector3> path = new List<Vector3>();

        Vector3 current = getStart().transform.position;

        path.Add(current);

        GameObject end = getEnd();

        PriorityQueue<AStarHelper> pq = new PriorityQueue<AStarHelper>();

        AStarHelper store = new AStarHelper(path, end.transform.position);

        pq.add(store);

        int maxTries = (int)(Math.Pow(grid.getHeight() * grid.getWidth(),2));

        int tries = 0;

        while (!(current.Equals(end.transform.position)) && tries < maxTries)
        {
            path = pq.poll().getPath();

            current = path[path.Count - 1]; //gets the latest one added

            List<Vector3> neigbors = getNeighbors(current);

            foreach(Vector3 spot in neigbors)
            {
                List<Vector3> newPath = path.ToList();

                newPath.Add(spot);

                AStarHelper next = new AStarHelper(path, end.transform.position);

                pq.add(next);
            }
            tries++;

        } 
        
        if(tries >= maxTries)
        {
            path = new List<Vector3>();
        }


        return path;
    }

    public void basicFun()
    {
        //List<Vector3> path = locate(); //Currently Has Bugs

       // Debug.Log(path);

        Debug.Log(getEnd());

        Debug.Log(getStart());

    }

}
