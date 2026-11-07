/*The Purpose of this program is to serve as a basic easy to kill enemy
 * 
 * @author ryan weinstein
 * 
 * Collaborators N\A
 */
using UnityEngine;

public class BasicEnemy : MonoBehaviour, IEnemyBase
{
    private int health = 5; //subject to change
    private float speed = 1; // subject to change

    /*Summary:
     *  returns the current health of the enemy
     * 
     * Return:
     *      what the enemies current health is
     * 
     */
    public int getHealth()
    {
        return health;
    }

    /*Summary:
     *      Applies the damage from the tower to the enemy that is given and if its health goes to or below 0 it dies
     * 
     * Parameter:
     *      damage:
     *          the amount of damage that you want to deal to this enemy
     * 
     */
    public void dealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }

    /*Summary:
     *      gets how much farther this object is from the end
     *      
     * Return:
     *      the remaning distance to the gate     
     * 
     */
    public float getDistToEnd()
    {
        return 0; // Requires A* to be implemeanted
    }
    /*Summary:
     *      moves the enemy along the A* path by its speed
     * 
     */
    public void move()
    {
        //Need another function mainly A* to function by getting the direction
        //Ill probaly implemeant a feature to move an object by appling a force or using its transform
    }

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
    public float getDistToObj(float objX, float objY)
    {
        float posX = this.transform.position.x;
        float posY = this.transform.position.y;
        float a = Mathf.Abs(posX - objX);
        float b = Mathf.Abs(posY - objY);// making sure everything is positive
        float c = Mathf.Abs(Mathf.Sqrt((Mathf.Pow(a,2) + Mathf.Pow(b,2)))); // Pythagorans theorm to get the hypotunese
        return c;
    }

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
    public int CompareTo(IEnemyBase obj)
    {
        if(obj == null)
        {
            return -1;
        }
        else if(obj.getDistToEnd() == getDistToEnd())
        {
            return 0;
        }
        else if(obj.getDistToEnd() > getDistToEnd())
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

}
