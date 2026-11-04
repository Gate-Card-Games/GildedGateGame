using UnityEngine;

public interface IEnemyBase
{
    public int getHealth();

    public void dealDamage(int damage);

    public float getDistToEnd();

    public void move();
}
