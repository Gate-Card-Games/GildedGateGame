using UnityEngine;

public interface IEnemyBase
{
    public int getHealth();

    public void dealDamage(int damage);

    public float getDistToEnd();

    public void move();

    public int Compare(IEnemyBase a, IEnemyBase b);
}
