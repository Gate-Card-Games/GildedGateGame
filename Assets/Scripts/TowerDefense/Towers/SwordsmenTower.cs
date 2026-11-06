using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class SwordsmenTower : TowerBase
{

    private IEnemyBase targetedEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setAttack(5);
        setAttackSpeed(0.2f);
        setRange(10);
    }

}
    
