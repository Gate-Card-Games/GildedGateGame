/* This class is made to allow me to make A* and other algorithims that require a grid
 * 
 * @author ryan weinstein
 * 
 * collaborators n\a
 * 
 */

using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width; //width of the grid

    [SerializeField] private int height; // height of the grid

    [SerializeField] private float cellSize;

    [SerializeField] private Transform cellPrefab;

    private GameObject[,] boxList;

    private List<Transform> gridSpots;

    //runs at the start of the program
    public void Start()
    {
        loadGrid();
        removeGrid();
        loadGrid();
    }

    /* Summary:
     *      creates the grid and instantates both lists
     * 
     * 
     */
    public void loadGrid()
    {
        float x = (this.transform.position.x);

        float y = (this.transform.position.y);

        float z = (this.transform.position.z);

        boxList = new GameObject[height, width];

        gridSpots = new List<Transform>();


        for(int i = 0; i < height; i++)
        {
            float tempX = x;
            for(int j = 0; j < width; j++)
            {
                var newObj = Instantiate(cellPrefab, new Vector3(tempX, y, z), this.transform.rotation, this.transform);
                newObj.transform.localScale = new Vector3(cellSize, cellSize, cellSize);
                tempX += cellSize;
                gridSpots.Add(newObj);
            }
            z += cellSize;
        }
    }

    /*Summary:
     *      return whats in the grid
     * 
     * Returns:
     *      the objects in the grid in a 2-D array
     */
    public GameObject[,] getItemsInGrid()
    {
        return boxList;
    }

    /*Summary:
     *      calculates and returns the postion of the spot closest to the given spot
     *      
     *Paramater:
     *      pos:
     *          the position that you want to check
     * 
     * Returns:
     *      the center of the cell closest to the position
     */
    public Vector3 getCellCenter(Vector3 pos)
    {
        for(int i = 0; i < gridSpots.Count; i++)
        {
            //getting the other values for easier use
            float posX = pos.x;
            float posZ = pos.z;

            //getting this obj positon
            float thisZ = gridSpots[i].transform.position.z;
            float thisX = gridSpots[i].transform.position.x;

            float dist = cellSize / 2;

            //Checks if its the square in range
            if(posX - dist <= thisX && posX + dist >= thisX && posZ - dist <= thisZ && posZ + dist >= thisZ)
            {
                return gridSpots[i].transform.position;
            }
        }

        return default; // just for a null case
    }

    /*Summary:
     *      calculates and returns the index of the spot closest to the given spot
     * Paramater:
     *      pos:
     *          the position that you want to check
     * 
     * Return:
     *      the index closest to the given spot
     */
    private int getIndexOfPos(Vector3 pos)
    {
        for (int i = 0; i < gridSpots.Count; i++)
        {
            //getting the other values for easier use
            float posX = pos.x;
            float posZ = pos.z;

            //getting this obj positon
            float thisZ = gridSpots[i].transform.position.z;
            float thisX = gridSpots[i].transform.position.x;

            float dist = cellSize / 2;

            //Checks if its the square in range
            if (posX - dist <= thisX && posX + dist >= thisX && posZ - dist <= thisZ && posZ + dist >= thisZ)
            {
                return i;
            }
        }

        return -1;
    }

    /**Summary:
     *      makes sure the object in the specified position is empty
     * 
     * Parameters:
     *      x:
     *          the x of the object
     *      y:
     *          the y of the object
     *      obj:
     *          the object you want to replace the old object
     * 
     */
    private void replaceSpot(int x, int y, GameObject obj)
    {
        if (!(boxList[y, x] == default))
        {
            Destroy(boxList[y, x]);
        }
        boxList[y, x] = obj;
    }

    /*Summary:
     *      places the given object at the closest position in the grid to the given postion
     *      
     *Parameters:
     *      obj:
     *          the given object
     *      
     *      pos:
     *          the given position
     * 
     */
    public void placeObject(GameObject obj, Vector3 pos)
    {
        int index = getIndexOfPos(pos);

        int x = index % width;

        int y = index / width;

       
        replaceSpot(x, y, obj);
    }

    /*Summary:
     *      checks if the position in the grid currenlty has something in it
     * 
     * Paramter:
     *      pos:
     *          the given position
     * 
     * Return:
     *      if the index is not null then true else its false
     */
    public bool isOccupied(Vector3 pos)
    {

        int index = getIndexOfPos(pos);

        int x = index % width;

        int y = index / width;
        if (x < 0)
            
            return false;
        else if (boxList[y , x] == default)
            return false;
        return true;
    }

    /*Summary:
     *      returns the cell size
     *
     *Return:
     *  the size of the cell
     */
    public float getCellSize()
    {
        return cellSize;
    }

    /*Summary:
     *      returns the width
     * 
     * Return:
     *      the width of the grid
     */
    public int getWidth() 
    { 
        return width; 
    }

    /*Summary:
     *      returns the height
     * 
     * Return:
     *      the height of the grid
     */
    public int getHeight()
    {
        return height;
    }

    /**Summary:
     *      deletes everything in the grid
     * 
     */
    public void removeGrid()
    {
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Destroy(gridSpots[j + (i * width)].gameObject);

                Destroy(boxList[i, j]);

                boxList[i, j] = default;
            }
        }
    }

    /**Summary
     *  changes the grid to the new grid provided
     *  
     *  Parameters:
     *      width:
     *          the new width of the grid
     *      height:
     *          the new height of the grid
     *      gridItems:
     *          the items you want in the grid
     *
     */
    public void changeGridItems(int width, int height, GameObject[,] gridItems)
    {
        this.width = width;
        this.height = height;
        removeGrid();
        boxList = gridItems;
        loadGrid();
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if (!(boxList[i,j].Equals(default)))
                {
                    GameObject obj = boxList[i, j];
                    obj.transform.position = gridSpots[j + (i * width)].position;
                    obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + cellSize / 2, obj.transform.position.z);
                }
            }
        }

    }

    /** Summary:
     *      returns the index's of all the neighbors
     *      
     *Parameter:
     *      pos:
     *          the position of the cell that you want to check
     *          
     *Return:
     *      a list of the index's of all cells that surround it
     */
    public List<int> getAllNeighbors(Vector3 pos)
    {
        int index = getIndexOfPos(pos);

        List<int> retArr = new List<int>();

        if (index == -1)
        {
            return retArr;
        }
        if (index - width >= 0)
        {
            retArr.Add(index - width);
        }
        if (index + width < width * height)
        {
            retArr.Add(index + width);
        }
        if(index % width + 1 < width)
        {
            retArr.Add(index + 1);
        }
        if(index % width - 1 >= 0)
        {
            retArr.Add(index - 1);
        }
        return retArr;
    }

}
