using System;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    int attack;

    float attackSpeed;

    int range;

    public void setAttack(int newAttack)
    {
        attack = newAttack;
    }

    public void setAttackSpeed(float newAttackSpeed)
    {
        attackSpeed = newAttackSpeed;
    }

    public void setRange(int newRange)
    {
        range = newRange;
    }

    public int getAttack()
    { return attack; }

    public int getRange()
    { return range; }

    public float getAttackSpeed()
    { return attackSpeed; }

    public abstract void Attack(IEnemyBase enemy);
}
