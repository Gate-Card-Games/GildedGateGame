using System;
using UnityEngine;

public interface IEnemyBase : IComparable<IEnemyBase>
{
    public int getHealth();

    public void dealDamage(int damage);

    public float getDistToEnd();

    public void move();

    public int CompareTo(IEnemyBase otherObject);
}
