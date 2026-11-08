/*This program is made to keep track of where the cards index is in the hand
 * 
 * @author ryan weinstein
 * 
 * collaborators n\a
 */
using UnityEngine;

public class PositionInHand : MonoBehaviour
{
    //instance var
    private int posInHand = -1;

    /*Summary:
     *      returns what the position in the hand is
     * 
     * Return:
     *      what the objects position in the hand is
     */
    public int getPositionInHand()
    {
        return posInHand;
    }

    /*Summary:
     *      changes what its index in the hand is to make the hand
     *      
     *Parameters:
     *      newPos:
     *          the new position in the hand
     */
    public void changePositionInHand(int newPos)
    {
        posInHand = newPos;
    }
}
