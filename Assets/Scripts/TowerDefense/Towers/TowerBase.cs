/*This inteface is used to be a base for all of the other towers
 * 
 * 
 * @author Ryan Weinstein
 * 
 * 
 * Collaborators N\A
 * 
 */
using System;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{

    //instance variables
    int attack;

    float attackSpeed;

    int range;

    private PriorityQueue<IEnemyBase> enemiesInRange = new PriorityQueue<IEnemyBase>();


    /*Summary:
     *      uses its Priority queue to get whatever the furthest along the track and in its range
     * 
     * Return:
     *      the enemy closest to the endpoint
     */
    public IEnemyBase getClosestEnemy()
    {
        return enemiesInRange.peek();
    }

    /*Summary:
     *      sets the attack power to whatever the parameter is
     * 
     * Parameter:
     *      newAttack:
     *          the new desired attack
     */
    public void setAttack(int newAttack)
    {
        attack = newAttack;
    }


    /*Summary:
     *      changes the attack speed to the new desired speed
     * 
     * Paramter:
     *      newAttackSpeed:
     *          the new desired attack speed
     */
    public void setAttackSpeed(float newAttackSpeed)
    {
        attackSpeed = newAttackSpeed;
    }

    /*Summary:
     *      changes the range to the new desired range
     * 
     * Paramter:
     *      newRange:
     *          the new desired range
     */
    public void setRange(int newRange)
    {
        range = newRange;
    }

    /*Summary:
     *      returns the attack
     *
     *Return:
     *      the attack value
     */
    public int getAttack()
    { return attack; }

    /*Summary:
    *      returns the attack range
    *
    *Return:
    *      the attack range value
    */
    public int getRange()
    { return range; }

    /*Summary:
    *      returns the attack speed
    *
    *Return:
    *      the attack speed value
    */
    public float getAttackSpeed()
    { return attackSpeed; }

    /*Summary:
     *      Adds the enemy to the PQ if its not in already in it and is in range
     * 
     * Parameters:
     *      enemy:
     *          The enemy that you want to check
     *          
     *  Return:
     *      If the enemy was added to the PQ
     */
    public bool addEnemyToList(IEnemyBase enemy)
    {
        if (!(isEnemyInRange(enemy)))
        {
            enemiesInRange.remove(enemy); //this function sees if its in the PQ before seeing if it can remove
            return false;
        }
            
        if (isEnemyInRange(enemy) && !enemiesInRange.Contains(enemy))
        {
            enemiesInRange.add(enemy);
            return true;
        }
        return false;
    }

    /*Summary:
     *      Checks if the enemy is in range of this tower object
     * 
     * Parameter:
     *      enemy:
     *          The enemy that you want to check
     *          
     *Return:
     *      true if the enemy is in range and false if it is not
     * 
     */
    private bool isEnemyInRange(IEnemyBase enemy)
    {
        float dist = enemy.getDistToObj(this.transform.position.x, this.transform.position.x);
        return dist <= getRange();
    }

    /*Summary:
     *      Deals damage equal to this towers attack to the enemy that is provided
     *      
     *Parameter:
     *      enemy:
     *          the enemy that you want to target
     * 
     */
    public void Attack(IEnemyBase enemy)
    {
        enemy.dealDamage(getAttack());
    }

}
