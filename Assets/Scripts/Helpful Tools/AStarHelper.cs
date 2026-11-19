using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AStarHelper : MonoBehaviour, IComparable<AStarHelper>
{
    private List<Vector3> path;

    private Vector3 endPosition;

    public AStarHelper(List<Vector3> path, Vector3 endPosition)
    {
        this.path = path;

        this.endPosition = endPosition;
    }

    public List<Vector3> getPath()
    {
        return path;
    }

    public int getValue()
    {
        return  (int)(Math.Abs(this.transform.position.x - endPosition.x) + Math.Abs(this.transform.position.y - endPosition.y)) + path.Count; // Gets the hueristic plus the path length
    }

    public int CompareTo(AStarHelper otherObject)
    {
        if (this == null || otherObject == null)
        {
            return 0;
        }
        return getValue() - otherObject.getValue();
    }
}
