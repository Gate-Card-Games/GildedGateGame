using System;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    IEnemyBase targetedEnemy;
    int attack;

    float attackSpeed;

    int range;

    private PriorityQueue<IEnemyBase> enemiesInRange = new PriorityQueue<IEnemyBase>();


    public IEnemyBase getClosestEnemy()
    {
        return enemiesInRange.peek();
    }

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

    public bool addEnemyToList(IEnemyBase enemy)
    {
        if (!(isEnemyInRange(enemy) && enemiesInRange.Contains(enemy)))
        {
            enemiesInRange.remove(enemy);
            return false;
        }
            
        if (isEnemyInRange(enemy) && !enemiesInRange.Contains(enemy))
        {
            enemiesInRange.add(enemy);
            return true;
        }
        return false;
    }
    private bool isEnemyInRange(IEnemyBase enemy)
    {
        float dist = enemy.getDistToObj(this.transform.position.x, this.transform.position.x);
        return dist <= getRange();
    }
    public void setEnemy(IEnemyBase newEnemy)
    {
        targetedEnemy = newEnemy;
    }

    public void Attack(IEnemyBase enemy)
    {
        enemy.dealDamage(getAttack());
    }

}
