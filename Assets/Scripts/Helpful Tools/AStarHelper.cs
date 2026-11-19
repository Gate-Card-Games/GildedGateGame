/**This program stores the stuff for my A* algorithm and is its used to compare it and store in the Priority Queue
 * 
 * @author ryan weinstein
 * 
 * collaborators N\A
 * 
 */

using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AStarHelper : IComparable<AStarHelper>
{
    private List<Vector3> path;

    private Vector3 endPosition;


    /**Summary:
     *      this function is used to change what this classes path variable is
     * 
     * Parameter:
     *      newPath: 
     *          the list of vector3 that you would like to set its path to
     *      
     */
    public void setPath(List<Vector3> newPath)
    {
        path = newPath;
    }

    /**Summary:
     *      this function is used to change what this classes endPosition variable is
     * 
     * Parameter:
     *      end:
     *          the Vector3 of the end object
     */
    public void setEnd(Vector3 end)
    {
        endPosition = end;
    }

    /**Summary:
     *      returns this classes path variable
     * 
     * Return:
     *      the path variable
     * 
     */
    public List<Vector3> getPath()
    {
        return path;
    }

    /** Summary:
     *      returns a value to be used for its compare to
     * 
     * Return:
     *      if the last value in path is not a Vector3 then the integer min value. else the hueristic to the end + the length of the path
     * 
     */
    public int getValue()
    {
        if(path.Count == 0)
        {
            return Int32.MaxValue;
        }

        Vector3 latest = path[path.Count - 1];

        if(latest == default)
        {
            return Int32.MaxValue;
        }

        return  (int)Math.Sqrt(Math.Pow(Math.Abs(latest.x - endPosition.x),2) + Math.Pow(Math.Abs(latest.z - endPosition.z),2)) + path.Count; // Gets the hueristic plus the path length
    }

    /**Summary:
     *      Compares this to another ones value
     *      
     *Return:
     *      the difference between them, but if either one doesn't exist then -1
     * 
     */
    public int CompareTo(AStarHelper otherObject)
    {
        if (this == default || otherObject == default)
        {
            return -1;
        }
        return getValue() - otherObject.getValue();
    }
}
