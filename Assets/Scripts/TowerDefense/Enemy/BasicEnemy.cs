/*The Purpose of this program is to serve as a basic easy to kill enemy
 * 
 * @author ryan weinstein
 * 
 * Collaborators N\A
 */
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, IEnemyBase
{
    [SerializeField] private List<Vector3> path;

    [SerializeField] private NexusHealth enemyNexus;

    private int health = 5; //subject to change
    private float speed = 1; // subject to change

    private int currentPos = 0;

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
        float sum = 0;
        for(int i = currentPos; i < path.Count - 1; i++)
        {
            sum += Mathf.Sqrt(Mathf.Pow(Mathf.Abs((path[i].x - path[i+1].x)), 2) + Mathf.Pow(Mathf.Abs(path[i].z - path[i + 1].z), 2));
        }

        return sum;
    }
    /*Summary:
     *      moves the enemy along the A* path by its speed
     * 
     */
    public void move()
    {
        float thisZ = this.transform.position.z;

        float thisX = this.transform.position.x;

        float endPosX = path[currentPos + 1].x;

        float endPosZ = path[currentPos + 1].z; //works because it destroys itself if it hits the last node and start and end are different

        float totalZ = thisZ - endPosZ;

        float totalX = thisX - endPosX;

        float distToNextPoint =  Mathf.Abs(totalZ + totalX); //One will always be 0

        if(distToNextPoint < speed)
        {
            this.transform.position = path[currentPos];
            currentPos += 1;
        }
        else if(thisX != 0)
        {
            if(thisX > 0)
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (thisZ > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }

        if(currentPos >= path.Count - 1)
        {
            enemyNexus.changeHealth(-1 * health);
            Destroy(this);
        }



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
