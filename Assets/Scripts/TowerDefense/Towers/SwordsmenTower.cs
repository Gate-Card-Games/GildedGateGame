/*The Purpose of this program is to serve as a the brains behind the swordsman tower
 * 
 * @author ryan weinstein
 * 
 * Collaborators N\A
 */

using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class SwordsmenTower : TowerBase
{

    private IEnemyBase targetedEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Just sets its values when it gets spawned in
    void Start()
    {
        setAttack(5);
        setAttackSpeed(0.2f);
        setRange(10);
    }

}
    
