/*The Purpose of this program is to be a logic center for the swordsmen card
 * 
 * @author ryan weinstein
 * 
 * Collaborators N\A
 */
using UnityEngine;
using UnityEngine.UI;

public class SwordsmenCard : MonoBehaviour, ICardBase, IDefensiveCard
{


    //instant variables

    private const int cost = 1;

    private const string cardName = "Swordsmen";

    private const string rarity = "Common";


    //Prefabs from the game

    [SerializeField] GameObject cardDisplay;

    [SerializeField] GameObject cardTower;

    /*Summary:
     *      Returns if the card has a tower side
     * Return:
     *      if the tower is a defensive card with a tower
     * 
     */

    public bool isDefensiveCard()
    {
        return true;
    }


    /*Summary:
     *      Returns whatever the cost of the card is
     * 
     * Return:
     *      the cost of the card
     * 
     */
    public int getCost()
    {
        return cost;
    }

    /*Summary:
     *      returns the name of the card
     *      
     *  Return:
     *      the name of the card
     * 
     * 
     */
    public string getName()
    {
        return cardName;
    }

    /*Summary:
     *      get the prefab of the card object
     * 
     *Return:
     *      the prefab of the card
     * 
     */
    public GameObject getCardDisplay()
    {
        return cardDisplay;
    }

    /*Summary:
    *      this function returns the rarity of the card
    * 
    * Returns:
    *      the rairty of the card (You can rename this to get level and change the description)
    */
    public string getRarity()
    {
        return rarity;
    }

    /*Summary:
    *      gets the value of the card for the shop to use
    *      
    *  Return:
    *      the value of the card in terms of 3-D world money
    */
    public int getValue() { return cost; } //IMPLEMENT LATER

    /*Summary:
     *      tells the card to do what the text of the card says it should do
     *          and activates it
     */
    public void activate() { return; }//Not used for this class

    /*Summary:
     *      returns the tower side of this card
     * 
     * Return:
     *      the prefab for the tower of this object
     *      
     */
    public GameObject place() { return cardTower; }


}
