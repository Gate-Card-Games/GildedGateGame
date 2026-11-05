using System;
using UnityEngine;

public interface IEnemyBase : IComparable<IEnemyBase>
{
    public int getHealth();

    public void dealDamage(int damage);

    public float getDistToEnd();

    public void move();
    
    //You need to implement a public int CompareTo(IEnemyBase otherObject);
}
