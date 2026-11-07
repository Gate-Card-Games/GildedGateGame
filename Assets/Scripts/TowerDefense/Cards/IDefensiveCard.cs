/*This is the base for all defensive cards
 * 
 * @author ryan weinstein
 * 

    collaborators n\a
 */

using UnityEngine;

public interface IDefensiveCard
{
    /*Summary:
     *      returns the tower side of this card
     * 
     * Return:
     *      the prefab for the tower of this object
     *      
     */
    public GameObject place();
}
