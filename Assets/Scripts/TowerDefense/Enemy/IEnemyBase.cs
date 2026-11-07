/*The Purpose of this program is to serve as a way for me to access all enemies
 * 
 * @author ryan weinstein
 * 
 * Collaborators N\A
 */
using System;
using UnityEngine;

public interface IEnemyBase : IComparable<IEnemyBase>
{
    /*Summary:
     *  returns the current health of the enemy
     * 
     * Return:
     *      what the enemies current health is
     * 
     */
    public int getHealth();

    /*Summary:
    *      Applies the damage from the tower to the enemy that is given and if its health goes to or below 0 it dies
    * 
    * Parameter:
    *      damage:
    *          the amount of damage that you want to deal to this enemy
    * 
    */
    public void dealDamage(int damage);

    /*Summary:
     *      gets how much farther this object is from the end
     *      
     * Return:
     *      the remaning distance to the gate     
     * 
     */
    public float getDistToEnd();

    /*Summary:
     *      moves the enemy along the A* path by its speed
     * 
     */
    public void move();

    /*Summary:
     *      gets the distance from this object to the specified object using the pythagorans theorm
     * 
     * Parameters:
     *      objX:
     *          the other objects x position
     *      
     *      objY:
     *          the other object y position
     *          
     *  Return:
     *      The shortest distance from this object to the other object
     * 
     */
    public float getDistToObj(float objX, float objY);




    /*Summary:
     *      compares this object with the other returning a value to denote which one is closer to the end
     *  
     *Parameter:
     *      obj:
     *          The other object that you want to compare
     * 
     * Return:
     *      1 if its further away 0 if its distance is equal -1 if its further away
     * 
     */
    //You need to implement a public int CompareTo(IEnemyBase otherObject);
}
