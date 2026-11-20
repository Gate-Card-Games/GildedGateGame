using UnityEngine;

public class NexusHealth : MonoBehaviour
{
    private int health = 100; //Value Can Change

    /**Summary:
     *      changes the health by the provided amount
     *      
     *Parameter:
     *      source:
     *          the amount you want to change the health by
     *          
     *Return:
     *      if the player dies after the source is added
     * 
     */
    public bool changeHealth(int source)
    {
        health += source;

        if (health <= 0)
        {
            return false;
        }
        return true;
    }

}
