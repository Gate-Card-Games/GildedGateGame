using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
//using DotNetty.Common.Utilities;

public class SwordsmenTower : TowerBase
{
    private IEnemyBase targetedEnemy;
    //private PriorityQueue<int> enemiesInRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setAttack(5);
        setAttackSpeed(0.2f);
        setRange(10);
    }

    public void setEnemy(IEnemyBase newEnemy) 
    {
        targetedEnemy = newEnemy;
    }

    override
    public void Attack(IEnemyBase enemy)
    {
        enemy.dealDamage(getAttack());
    }

    public bool addEnemyToList(IEnemyBase enemy)
    {

        return false;
    }
    private bool isEnemyInRange(IEnemyBase enemy)
    {
        return false;
    }
}
